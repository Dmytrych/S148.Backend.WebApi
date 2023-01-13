using NovaPoshtaApi;
using S148.Backend.Extensibility.NovaPoshta.Models;
using S148.Backend.Extensibility.NovaPoshta.ParameterCreators;

namespace S148.Backend.Extensibility.NovaPoshta.OnlineSettlementSearch;

public class QuickCitySearchClient : ApiClient, IQuickCitySearchClient
{
    private readonly IParameterCreator<LimitedQuickCityParameters, QuickCityFilter> quickCityParameterCreator;
    
    public QuickCitySearchClient(
        IApiConnection apiConnection,
        IParameterCreator<LimitedQuickCityParameters, QuickCityFilter> quickCityParameterCreator)
        : base(apiConnection)
    {
        this.quickCityParameterCreator = quickCityParameterCreator;
    }
    
    public async Task<IEnumerable<QuickCityData>> GetCity(string cityName, int limit, int page)
    {
        var cityFilter = new QuickCityFilter
        {
            CityName = cityName,
            Limit = limit,
            Page = page
        };
        return await GetCities(cityFilter);
    }

    private async Task<IEnumerable<QuickCityData>> GetCities(QuickCityFilter quickCityFilter)
    {
        var request = new LimitedQuickCityRequest(quickCityParameterCreator.Create(quickCityFilter), ApiConnection.ApiKey);
        return await ApiConnection.Get<IEnumerable<QuickCityData>, Info, LimitedQuickCityParameters>(request);
    }
}