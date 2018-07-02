using System.Collections.Generic;

namespace Yandex.Geocoder.Models
{
    public class GeoObjectCollectionType
    {
        public GeoObjectCollectionType()
        {
            MetaDataProperty = new ResponseMetaDataPropertyType();
            FeatureMember = new List<FeatureMemberType>();
        }

        public ResponseMetaDataPropertyType MetaDataProperty { get; set; }

        public List<FeatureMemberType> FeatureMember { get; set; }
    }
}
