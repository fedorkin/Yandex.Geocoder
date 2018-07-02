# Yandex.Geocoder

Geocoding is easy.
For forward geocoding you should create GeocodeRequest and execute it.
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

For reverse geocoding you shoulc create ReverseGeocodreRequest.
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

Also you may use all additional parameters from https://tech.yandex.ru/maps/doc/geocoder/desc/concepts/input_params-docpage/
