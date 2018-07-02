namespace Yandex.Geocoder.Enums
{
    public enum PrecisionKind
    {
        /// <summary>
        /// Точное соответствие.
        /// </summary>
        Exact,

        /// <summary>
        /// Совпал номер дома, но не совпало строение или корпус.
        /// </summary>
        Number,

        /// <summary>
        /// Найден дом с номером, близким к запрошенному.
        /// </summary>
        Near,

        /// <summary>
        /// Ответ содержит приблизительные координаты запрашиваемого дома.
        /// </summary>
        Range,

        /// <summary>
        /// Найдена только улица.
        /// </summary>
        Street,

        /// <summary>
        /// Улица не найдена, но найден, например, посёлок, район и т. п.
        /// </summary>
        Other
    }
}
