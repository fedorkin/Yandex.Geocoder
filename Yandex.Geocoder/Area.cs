namespace Yandex.Geocoder
{
    public struct Area
    {
        public double Latitude;
        public double Longitude;

        public double LatitudeSpan;
        public double LongitudeSpan;

        public Area(double latitude, double longitude, double latitudeSpan, double longitudeSpan)
        {
            Latitude = latitude;
            Longitude = longitude;

            LatitudeSpan = latitudeSpan;
            LongitudeSpan = longitudeSpan;
        }

        public bool IsEmpty()
        {
            return Latitude.Equals(0) && Longitude.Equals(0) && LatitudeSpan.Equals(0) && LongitudeSpan.Equals(0);
        }
    }
}