using NovaPoshtaApi;
using S148.Backend.Extensibility.NovaPoshta.Models;
using S148.Backend.Extensibility.NovaPoshta.OnlineSettlementSearch;

namespace S148.Backend.Extensibility.NovaPoshta;

public interface ILimitableAddressClient : IAddressClient
{
    IQuickCitySearchClient QuickCitySearchClient { get; }
    
    Task<IEnumerable<Warehouse>> GetWarehouses(WarehouseFilter filter);

    Task<IEnumerable<City>> GetCities(CityFilter cityFilter);
}