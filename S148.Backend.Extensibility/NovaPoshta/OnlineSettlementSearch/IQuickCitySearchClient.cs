namespace S148.Backend.Extensibility.NovaPoshta.OnlineSettlementSearch;

public interface IQuickCitySearchClient
{
    Task<IEnumerable<QuickCityData>> GetCity(string cityName, int limit, int page);
}