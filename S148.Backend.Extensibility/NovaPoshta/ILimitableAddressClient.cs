using NovaPoshtaApi;
using S148.Backend.Extensibility.NovaPoshta.Models;

namespace S148.Backend.Extensibility.NovaPoshta;

public interface ILimitableAddressClient : IAddressClient
{
    Task<IEnumerable<Warehouse>> GetWarehouses(WarehouseFilter filter);

    Task<IEnumerable<City>> GetCities(CityFilter cityFilter);
}