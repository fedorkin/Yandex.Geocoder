using System;
namespace Yandex.Geocoder.Models
{
    public class GeoObjectType
    {
        public GeoObjectType()
        {
            MetaDataProperty = new MetaDataPropertyType();
            BoundedBy = new BoundedByType();
            Point = new PointType();
        }

        public MetaDataPropertyType MetaDataProperty { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public BoundedByType BoundedBy { get; set; }

        public PointType Point { get; set; }
    }
}
