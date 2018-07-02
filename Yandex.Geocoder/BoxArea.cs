namespace Yandex.Geocoder
{
    public struct BoxArea
    {
        public double LowerLatitude;
        public double LowerLongitude;

        public double UpperLatitude;
        public double UpperLongitude;

        public BoxArea (double lowerLatitude, double lowerLongitude, double upperLatitude, double upperLongitude)
        {
            LowerLatitude = lowerLatitude;
            LowerLongitude = lowerLongitude;

            UpperLatitude = upperLatitude;
            UpperLongitude = upperLongitude;
        }

        public bool IsEmpty()
        {
            return LowerLatitude.Equals(0) && LowerLongitude.Equals(0) && UpperLatitude.Equals(0) && UpperLongitude.Equals(0);
        }
    }
}