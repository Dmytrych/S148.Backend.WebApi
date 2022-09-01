using NovaPoshtaApi;

namespace S148.Backend.NovaPoshta.Extensibility.Services;

public interface IDeliveryInfoService
{
    Task<IReadOnlyCollection<City>> GetCitiesAsync(string nameFilter);

    Task<IReadOnlyCollection<Warehouse>> GetWarehousesAsync(string cityId, string cityName, int limit);
}