namespace Yandex.Geocoder.Models
{
    public class GeocoderResponseType
    {
        public GeocoderResponseType()
        {
            GeoObjectCollection = new GeoObjectCollectionType();
        }

        public GeoObjectCollectionType GeoObjectCollection { get; set; }
    }
}