namespace Yandex.Geocoder
{
    public abstract class BaseGeocoderRequest
    {
        public const string DefaultLanguage = "ru_RU";
        public const int DefaultMaxCount = 5;

        protected BaseGeocoderRequest()
        {
            Language = DefaultLanguage;
            MaxCount = DefaultMaxCount;
        }

        public string Language { get; set; }

        public int MaxCount { get; set; }
    }
}