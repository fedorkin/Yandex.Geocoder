using Yandex.Geocoder.Models;

namespace Yandex.Geocoder.Extenstions
{
    public static class StringExtension
    {
        public static Coordinate ToCoordinate(this string strCoordinate)
        {
            return new Coordinate(strCoordinate);
        }
    }
}