using NovaPoshtaApi;
using S148.Backend.Extensibility;

namespace S148.Backend.NovaPoshta.Extensibility.Repositories;

public interface INovaPoshtaInfoRepository
{
    Task<IReadOnlyCollection<City>> GetCitiesByName(string name);

    Task<IReadOnlyCollection<Warehouse>> GetWarehouses(string cityId, string cityName, int limit);

    Task<OperationResult<Warehouse>> GetWarehouseByNumberAsync(string cityId, string cityName, int warehouseNumber);
    
    Task<OperationResult<City>> GetCityByIdAsync(string cityId);

    Task<OperationResult<Area>> GetAreaByIdAsync(string areaId);
}