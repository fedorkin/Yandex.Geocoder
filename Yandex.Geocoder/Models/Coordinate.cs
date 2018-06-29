namespace Yandex.Geocoder.Models
{
    public class Coordinate
    {
        const int LongitudePartIndex = 0;
        const int LatitudePartIndex = 1;

        public Coordinate(string source)
        {
            Source = source;
        }

        public Coordinate(double latitude, double longitude)
        {
            Source = $"{longitude} {latitude}";
        }

        public string Source { get; protected set; }

        public double Latitude { get => GetLatitude(); }

        public double Longitude { get => GetLongitude(); }

        protected double GetLatitude()
        {
            var latitudeStr = GetSourcePart(LatitudePartIndex);

            return double.Parse(latitudeStr);
        }

        protected double GetLongitude()
        {
            var LongitudeStr = GetSourcePart(LongitudePartIndex);

            return double.Parse(LongitudeStr);
        }

        protected string GetSourcePart(int partIndex)
        {
            var result = string.Empty;

            var parts = Source.Split(' ');
            if (parts.Length > partIndex)
            {
                result = parts[partIndex];
            }

            return result;
        }
    }
}
