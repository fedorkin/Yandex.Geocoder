namespace Yandex.Geocoder.Models
{
    public class MetaDataPropertyType
    {
        public MetaDataPropertyType()
        {
            GeocoderMetaData = new GeocoderMetaDataType();
        }

        public GeocoderMetaDataType GeocoderMetaData { get; set; }
    }
}
