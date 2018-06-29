namespace Yandex.Geocoder
{
    public class GeocoderRequest
    {
        public const string DefaultLanguage = "ru_RU";

        public GeocoderRequest()
        {
            Language = DefaultLanguage;
        }

        public string Query { get; set; }

        public string Language { get; set; }
    }
}