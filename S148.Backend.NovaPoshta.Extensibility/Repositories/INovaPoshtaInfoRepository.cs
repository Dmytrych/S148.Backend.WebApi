using ErrorOr;
using S148.Backend.Extensibility.NovaPoshta.Models;

namespace S148.Backend.NovaPoshta.Extensibility.Repositories;

public interface INovaPoshtaInfoRepository
{
    Task<IReadOnlyCollection<City>> GetCitiesByName(string name);

    Task<ErrorOr<Warehouse>> GetWarehouseByNumberAsync(Guid cityGuidRef, int warehouseNumber);
    
    Task<ErrorOr<City>> GetCityByIdAsync(Guid cityGuidRef);

    Task<ErrorOr<Area>> GetAreaByIdAsync(Guid areaGuidRef);
}