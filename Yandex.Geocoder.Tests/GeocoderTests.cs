using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Yandex.Geocoder.Models.Address;
using Yandex.Geocoder.Extenstions;
using Yandex.Geocoder.Request;

namespace Yandex.Geocoder.Tests
{
    public class GeocoderTests
    {
        [Fact]
        public async Task GeocodeCity()
        {
            var request = new GeocoderRequest { Request = "Ярославль серова 13" };
            var client = new GeocoderClient();

            var response = await client.Geocode(request);

            var firstGeoObject = response.GeoObjectCollection.FeatureMember.FirstOrDefault();
            var coordinate = firstGeoObject.GeoObject.Point.Pos;
            var addressComponents = firstGeoObject.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components;
            var country = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Country));
            var province = addressComponents.LastOrDefault(c => c.Kind.Equals(AddressComponentKind.Province));
            var area = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Area));
            var city = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Locality));
            var street = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Street));
            var house = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.House));

            Assert.Equal("Россия", country.Name);
            Assert.Equal("Ярославская область", province.Name);
            Assert.Equal("городской округ Ярославль", area.Name);
            Assert.Equal("Ярославль", city.Name);
            Assert.Equal("улица Серова", street.Name);
            Assert.Equal("13", house.Name);
            Assert.Equal("39.802311 57.608719", coordinate);
        }

        [Fact]
        public async Task GeocodeSettlementWithoutStreet()
        {
            var request = new GeocoderRequest { Request = "Ярославская область Октябрьский 12" };
            var client = new GeocoderClient();

            var response = await client.Geocode(request);

            var firstGeoObject = response.GeoObjectCollection.FeatureMember.FirstOrDefault();
            var coordinate = firstGeoObject.GeoObject.Point.Pos;
            var addressComponents = firstGeoObject.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components;
            var country = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Country));
            var province = addressComponents.LastOrDefault(c => c.Kind.Equals(AddressComponentKind.Province));
            var area = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Area));
            var city = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Locality));
            var street = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Street));
            var house = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.House));

            Assert.Equal("Россия", country.Name);
            Assert.Equal("Ярославская область", province.Name);
            Assert.Equal("Рыбинский район", area.Name);
            Assert.Equal("поселок Октябрьский", city.Name);
            Assert.Null(street);
            Assert.Equal("12", house.Name);
            Assert.Equal("39.110177 57.984794", coordinate);
        }

        [Fact]
        public async Task ReverseGeocode()
        {
            var request = new ReverseGeocoderRequest { Latitude = 58.046733, Longitude = 38.841715 };
            var client = new GeocoderClient();

            var response = await client.ReverseGeocode(request);

            var firstGeoObject = response.GeoObjectCollection.FeatureMember.FirstOrDefault();
            var addressComponents = firstGeoObject.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components;
            var country = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Country));
            var province = addressComponents.LastOrDefault(c => c.Kind.Equals(AddressComponentKind.Province));
            var area = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Area));
            var city = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Locality));
            var street = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Street));
            var house = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.House));

            Assert.Equal("Россия", country.Name);
            Assert.Equal("Ярославская область", province.Name);
            Assert.Equal("городской округ Рыбинск", area.Name);
            Assert.Equal("Рыбинск", city.Name);
            Assert.Equal("улица Бородулина", street.Name);
            Assert.Equal("23", house.Name);
        }

        [Fact]
        public async Task RestrictionOfObjectsReturnedByReverseGeocoding()
        {
            var request = new ReverseGeocoderRequest { Latitude = 58.046733, Longitude = 38.841715, Kind = AddressComponentKind.Locality };
            var client = new GeocoderClient();

            var response = await client.ReverseGeocode(request);

            var firstGeoObject = response.GeoObjectCollection.FeatureMember.FirstOrDefault();
            var addressComponents = firstGeoObject.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components;
            var province = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Province));
            var city = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Locality));
            var street = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Street));

            Assert.Equal("Центральный федеральный округ", province.Name);
            Assert.Equal("Рыбинск", city.Name);
            Assert.Null(street);
        }

        [Fact]
        public async Task ParseCoordinates()
        {
            var request = new GeocoderRequest { Request = "Ярославская область Октябрьский 12" };
            var client = new GeocoderClient();

            var response = await client.Geocode(request);

            var firstGeoObject = response.GeoObjectCollection.FeatureMember.FirstOrDefault();
            var strCoordinate = firstGeoObject.GeoObject.Point.Pos;
            var coordinate = strCoordinate.ToCoordinate();

            Assert.Equal("39.110177 57.984794", strCoordinate);
            Assert.Equal(57.984794, coordinate.Latitude);
            Assert.Equal(39.110177, coordinate.Longitude);
        }

        [Fact]
        public async Task RestrictSearchArea()
        {
            var firstRequest = new GeocoderRequest
            {
                Request = "Песочное",
                SearchArea = new Area { Latitude = 59.300000, Longitude = 39.500000, LatitudeSpan = 0.500000, LongitudeSpan = 0.500000 },
                IsRestrictArea = true
            };
            var client = new GeocoderClient();
            var firstResponse = await client.Geocode(firstRequest);
            var firstResponseGeoObject = firstResponse.GeoObjectCollection.FeatureMember.FirstOrDefault();
            var firstResponseAddressComponents = firstResponseGeoObject.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components;
            var firstResponseProvince = firstResponseAddressComponents.LastOrDefault(c => c.Kind.Equals(AddressComponentKind.Province));
            var firstResponseLocality = firstResponseAddressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Locality));

            var secondRequest = new GeocoderRequest
            {
                Request = "Песочное",
                SearchArea = new Area { Latitude = 58.00400, Longitude = 39.200000, LatitudeSpan = 0.500000, LongitudeSpan = 0.500000 },
                IsRestrictArea = true
            };
            var secondResponse = await client.Geocode(secondRequest);
            var secondResponseGeoObject = secondResponse.GeoObjectCollection.FeatureMember.FirstOrDefault();
            var secondResponseAddressComponents = secondResponseGeoObject.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components;
            var secondResponseProvince = secondResponseAddressComponents.LastOrDefault(c => c.Kind.Equals(AddressComponentKind.Province));
            var secondResponseLocality = secondResponseAddressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Locality));

            Assert.Equal("Вологодская область", firstResponseProvince.Name);
            Assert.Equal("поселок Песочное", firstResponseLocality.Name);

            Assert.Equal("Ярославская область", secondResponseProvince.Name);
            Assert.Equal("поселок Песочное", secondResponseLocality.Name);
        }

        [Fact]
        public async Task FindGeoObjectInBordersArea()
        {
            var firstRequest = new GeocoderRequest
            {
                Request = "Песочное",
                BordersArea = new BoxArea { LowerLatitude = 59.440733, LowerLongitude = 39.641063, UpperLatitude = 59.457845, UpperLongitude = 39.666459 },
                IsRestrictArea = true
            };
            var client = new GeocoderClient();
            var firstResponse = await client.Geocode(firstRequest);
            var firstResponseGeoObject = firstResponse.GeoObjectCollection.FeatureMember.FirstOrDefault();
            var firstResponseAddressComponents = firstResponseGeoObject.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components;
            var firstResponseProvince = firstResponseAddressComponents.LastOrDefault(c => c.Kind.Equals(AddressComponentKind.Province));
            var firstResponseLocality = firstResponseAddressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Locality));

            Assert.Equal("Вологодская область", firstResponseProvince.Name);
            Assert.Equal("поселок Песочное", firstResponseLocality.Name);
        }

        [Fact]
        public async Task NotFindGeoObjectInBordersArea()
        {
            var firstRequest = new GeocoderRequest
            {
                Request = "Песочное",
                BordersArea = new BoxArea { LowerLatitude = 59.600000, LowerLongitude = 41.641063, UpperLatitude = 59.700000, UpperLongitude = 41.666459 },
                IsRestrictArea = true
            };

            var client = new GeocoderClient();
            var firstResponse = await client.Geocode(firstRequest);
            var firstResponseGeoObject = firstResponse.GeoObjectCollection.FeatureMember.FirstOrDefault();
          
            Assert.Null(firstResponseGeoObject);
        }

        [Fact]
        public async Task LimitNumberOfReturnedGeoObjects()
        {
            var client = new GeocoderClient();

            var unlimitedResponse = await client.Geocode(new GeocoderRequest { Request = "Серова" });
            var unlimitedGeoObjectCount = unlimitedResponse.GeoObjectCollection.FeatureMember.Count;

            var limitedResponse = await client.Geocode(new GeocoderRequest { Request = "Серова", MaxCount = 1});
            var limitedGeoObjectCount = limitedResponse.GeoObjectCollection.FeatureMember.Count;

            Assert.True(unlimitedGeoObjectCount > limitedGeoObjectCount);
        }
    }
}