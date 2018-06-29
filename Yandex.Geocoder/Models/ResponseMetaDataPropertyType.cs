namespace Yandex.Geocoder.Models
{
    public class ResponseMetaDataPropertyType
    {
        public ResponseMetaDataPropertyType()
        {
            GeocoderResponseMetaData = new GeocoderResponseMetaDataType();
        }

        public GeocoderResponseMetaDataType GeocoderResponseMetaData { get; set; }
    }
}
