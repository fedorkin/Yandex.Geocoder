using System.Collections.Generic;

namespace Yandex.Geocoder.Models.Address
{
    public class AddressType
    {
        public AddressType()
        {
            Components = new List<AddressComponentType>();
        }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }

        public string Formatted { get; set; }

        public List<AddressComponentType> Components { get; set; }
    }
}