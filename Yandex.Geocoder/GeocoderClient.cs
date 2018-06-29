using System;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using Yandex.Geocoder.Models;

namespace Yandex.Geocoder
{
    public class GeocoderClient
    {
        public const string DefaultGeocoderBaseUrl = "https://geocode-maps.yandex.ru/1.x/";

        public GeocoderClient(string key = null)
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

        public async Task<GeocoderResponseType> ExecuteQuery(GeocoderRequest request)
        {
            var restRequest = new RestRequest(Method.GET);

            restRequest.AddQueryParameter("geocode", request.Query);
            restRequest.AddQueryParameter("format", "json");
            restRequest.AddQueryParameter("lang", request.Language);

            var response = await Client.ExecuteTaskAsync<GeocoderResponse>(restRequest);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Data.Response;
        }
    }
}