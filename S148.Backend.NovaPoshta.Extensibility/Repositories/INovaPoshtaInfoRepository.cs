using S148.Backend.Extensibility;
using S148.Backend.Extensibility.NovaPoshta.Models;

namespace S148.Backend.NovaPoshta.Extensibility.Repositories;

public interface INovaPoshtaInfoRepository
{
    Task<IReadOnlyCollection<City>> GetCitiesByName(string name);

    Task<OperationResult<Warehouse>> GetWarehouseByNumberAsync(Guid cityGuidRef, int warehouseNumber);
    
    Task<OperationResult<City>> GetCityByIdAsync(Guid cityGuidRef);

    Task<OperationResult<Area>> GetAreaByIdAsync(Guid areaGuidRef);
}