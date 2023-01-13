using NovaPoshtaApi;

namespace S148.Backend.Extensibility.NovaPoshta;

public class LimitedCityRequest : AddressRequest<LimitedCityParameters>
{
    public LimitedCityRequest(LimitedCityParameters cityParameters, string apiKey)
        : base(apiKey, NovaPoshtaApiMethodNames.GetCities)
    {
        methodProperties = cityParameters;
    }
}