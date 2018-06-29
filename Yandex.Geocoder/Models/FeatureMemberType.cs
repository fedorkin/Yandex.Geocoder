namespace Yandex.Geocoder.Models
{
    public class FeatureMemberType
    {
        public FeatureMemberType()
        {
            GeoObject = new GeoObjectType();
        }

        public GeoObjectType GeoObject { get; set; }
    }
}