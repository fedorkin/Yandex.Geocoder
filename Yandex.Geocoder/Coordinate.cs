using System.Globalization;

namespace Yandex.Geocoder
{
    public class Coordinate
    {
        const int LongitudePartIndex = 0;
        const int LatitudePartIndex = 1;

        public Coordinate(string source)
        {
            Parse(source);
        }

        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; protected set; }

        public double Longitude { get; protected set; }

        protected void Parse(string source)
        {
            var result = string.Empty;

            var parts = source.Split(' ', ',');

            if (parts.Length == 2)
            {
                var longitudeStr = parts[LongitudePartIndex];
                var latitudeStr = parts[LatitudePartIndex];

                Longitude = double.Parse(longitudeStr, CultureInfo.InvariantCulture);
                Latitude = double.Parse(latitudeStr, CultureInfo.InvariantCulture);
            }
        }

        public override string ToString()
        {
            return $"{Longitude.ToString(CultureInfo.InvariantCulture)},{Latitude.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}