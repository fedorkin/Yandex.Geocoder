using Yandex.Geocoder.Request;

namespace Yandex.Geocoder
{
    public class GeocoderRequest : BaseGeocoderRequest
    {
        public string Request { get; set; }

        public Area SearchArea { get; set; }

        public BoxArea BordersArea { get; set; }

        public bool IsRestrictArea { get; set; }
    }
}