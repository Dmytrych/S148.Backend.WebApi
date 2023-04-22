using ErrorOr;
using S148.Backend.Extensibility.NovaPoshta.Models;

namespace S148.Backend.NovaPoshta.Extensibility.Services;

public interface IDeliveryInfoService
{
    Task<IReadOnlyCollection<City>> GetCitiesAsync(string nameFilter);

    Task<ErrorOr<Warehouse>> GetWarehouseByNumberAsync(Guid cityId, int warehouseId);

    Task<ErrorOr<Area>> GetArea(Guid areaGuidRef);
}