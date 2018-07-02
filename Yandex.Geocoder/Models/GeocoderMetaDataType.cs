using Yandex.Geocoder.Enums;
using Yandex.Geocoder.Models.Address;

namespace Yandex.Geocoder.Models
{
    public class GeocoderMetaDataType
    {
        public GeocoderMetaDataType()
        {
            Address = new AddressType();
        }

        public AddressComponentKind Kind { get; set; }

        public string Text { get; set; }

        public PrecisionKind Precision { get; set; }

        public AddressType Address { get; set; }
    }
}
