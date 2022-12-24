using NovaPoshtaApi;
using S148.Backend.Extensibility;

namespace S148.Backend.NovaPoshta.Extensibility.Services;

public interface IDeliveryInfoService
{
    Task<IReadOnlyCollection<City>> GetCitiesAsync(string nameFilter);

    Task<OperationResult<Warehouse>> GetWarehouseByNumberAsync(string cityId, string cityName, int warehouseId);

    Task<OperationResult<Area>> GetArea(string areaGuidRef);
}