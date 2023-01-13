using NovaPoshtaApi;

namespace S148.Backend.Extensibility.NovaPoshta.OnlineSettlementSearch;

public class LimitedQuickCityRequest : AddressRequest<LimitedQuickCityParameters>
{
    public LimitedQuickCityRequest(LimitedQuickCityParameters limitedQuickCityParameters, string apiKey)
        : base(apiKey, NovaPoshtaApiMethodNames.SearchSettlements)
    {
        methodProperties = limitedQuickCityParameters;
    }
}