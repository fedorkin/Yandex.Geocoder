using Yandex.Geocoder.Enums;

namespace Yandex.Geocoder
{
    public class ReverseGeocoderRequest : BaseGeocoderRequest
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public AddressComponentKind Kind { get; set; }
    }
}