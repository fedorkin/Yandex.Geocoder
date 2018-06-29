using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Yandex.Geocoder.Models.Address;

namespace Yandex.Geocoder.Tests
{
    public class GeocoderTests
    {
        [Fact]
        public async Task GetAddressByStringRequest()
        {
            var request = new GeocoderRequest { Query = "Рыбинск" };
            var geocoder = new GeocoderClient();

            var response = await geocoder.ExecuteQuery(request);

            var firstGeoObject = response.GeoObjectCollection.FeatureMember.FirstOrDefault();

            var city = firstGeoObject.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Locality));
            Assert.Equal("Рыбинск", city.Name);
        }
    }
}