using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using Yandex.Geocoder.Models;
using Yandex.Geocoder.Models.Address;

namespace Yandex.Geocoder
{
    public class GeocoderClient
    {
        public const string DefaultGeocoderBaseUrl = "https://geocode-maps.yandex.ru/1.x/";

        public GeocoderClient()
            : this(null)
        {
        }

        public GeocoderClient(string key)
        {
            Key = key;
            Client = new RestClient(DefaultGeocoderBaseUrl);
        }

        public string Key { get; }

        public IWebProxy Proxy
        {
            get => Client.Proxy;

            set => Client.Proxy = value;
        }

        protected RestClient Client { get; }

        public Task<GeocoderResponseType> Geocode(GeocoderRequest geocoderRequest)
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddQueryParameter("geocode", geocoderRequest.Request);

            if (!geocoderRequest.BordersArea.IsEmpty() || !geocoderRequest.SearchArea.IsEmpty())
            {
                restRequest.AddQueryParameter("rspn", Convert.ToInt32(geocoderRequest.IsRestrictArea).ToString());

                if (!geocoderRequest.BordersArea.IsEmpty())
                {
                    var lowerLeftCorner = new Coordinate(geocoderRequest.BordersArea.LowerLatitude, geocoderRequest.BordersArea.LowerLongitude);
                    var upperRightCorner = new Coordinate(geocoderRequest.BordersArea.UpperLatitude, geocoderRequest.BordersArea.UpperLongitude);

                    restRequest.AddQueryParameter("bbox", $"{lowerLeftCorner.ToString()}~{upperRightCorner.ToString()}");
                }
                else
                {
                    var coordiante = new Coordinate(geocoderRequest.SearchArea.Latitude, geocoderRequest.SearchArea.Longitude);
                    var span = new Coordinate(geocoderRequest.SearchArea.LatitudeSpan, geocoderRequest.SearchArea.LongitudeSpan);

                    restRequest.AddQueryParameter("ll", coordiante.ToString());
                    restRequest.AddQueryParameter("spn", span.ToString());
                }
            }

            return ExecuteQuery(restRequest, geocoderRequest);
        }

        public Task<GeocoderResponseType> ReverseGeocode(ReverseGeocoderRequest reverseGeocoderRequest)
        {
            var restRequest = new RestRequest(Method.GET);
            if (!reverseGeocoderRequest.Kind.Equals(AddressComponentKind.None))
            {
                restRequest.AddQueryParameter("kind", reverseGeocoderRequest.Kind.ToString().ToLower());
            }

            var coordiante = new Coordinate(reverseGeocoderRequest.Latitude, reverseGeocoderRequest.Longitude);
            restRequest.AddQueryParameter("geocode", coordiante.ToString());

            return ExecuteQuery(restRequest, reverseGeocoderRequest);
        }

        protected async Task<GeocoderResponseType> ExecuteQuery(RestRequest restRequest, BaseGeocoderRequest baseGeocoderRequest)
        {
            restRequest.AddQueryParameter("format", "json");
            restRequest.AddQueryParameter("lang", baseGeocoderRequest.Language);

            if (!string.IsNullOrEmpty(Key))
            {
                restRequest.AddQueryParameter("apikey", Key);
            }

            restRequest.AddQueryParameter("results", baseGeocoderRequest.MaxCount.ToString());

            var response = await Client.ExecuteTaskAsync<GeocoderResponse>(restRequest);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Data.Response;
        }
    }
}