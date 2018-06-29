using Yandex.Geocoder.Models;

namespace Yandex.Geocoder
{
    public class GeocoderResponse
    {
        public GeocoderResponse()
        {
            Response = new GeocoderResponseType();
        }

        public GeocoderResponseType Response { get; set; }
    }
}