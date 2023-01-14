using S148.Backend.Extensibility;
using S148.Backend.Extensibility.NovaPoshta.Models;

namespace S148.Backend.NovaPoshta.Extensibility.Services;

public interface IDeliveryInfoService
{
    Task<IReadOnlyCollection<City>> GetCitiesAsync(string nameFilter);

    Task<OperationResult<Warehouse>> GetWarehouseByNumberAsync(Guid cityId, int warehouseId);

    Task<OperationResult<Area>> GetArea(Guid areaGuidRef);
}