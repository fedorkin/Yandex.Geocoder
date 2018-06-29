namespace Yandex.Geocoder.Models.Address
{
    public enum AddressComponentKind
    {
        /// <summary>
        /// Отдельный дом
        /// </summary>
        House,

        /// <summary>
        /// Улица
        /// </summary>
        Street,

        /// <summary>
        /// Станция метро
        /// </summary>
        Metro,

        /// <summary>
        /// Район города
        /// </summary>
        District,

        /// <summary>
        /// Населённый пункт: город / поселок / деревня / село и т. п.
        /// </summary>
        Locality,

        /// <summary>
        /// Район области
        /// </summary>
        Area,

        /// <summary>
        /// Область
        /// </summary>
        Province,

        /// <summary>
        /// Страна
        /// </summary>
        Country,

        /// <summary>
        /// Река / озеро / ручей / водохранилище и т. п.
        /// </summary>
        Hydro,

        /// <summary>
        /// Ж.д. станция
        /// </summary>
        Railway,

        /// <summary>
        /// Линия метро / шоссе / ж.д. линия
        /// </summary>
        Route,

        /// <summary>
        /// Лес / парк / сад и т. п.
        /// </summary>
        Vegetation,

        /// <summary>
        /// Аэропорт
        /// </summary>
        Airport,

        /// <summary>
        /// Прочее
        /// </summary>
        Other
    }
}
