using S148.Backend.Extensibility.NovaPoshta.Models;

namespace S148.Backend.Extensibility.NovaPoshta;

public interface IAddressClient
{
    Task<IEnumerable<City>> GetCities();

    Task<IEnumerable<City>> GetCities(string id);

    Task<IEnumerable<City>> GetCitiesByName(string name);

    Task<IEnumerable<Area>> GetAreas();

    Task<IEnumerable<Warehouse>> GetWarehouses();

    Task<IEnumerable<Warehouse>> GetWarehouses(string cityId);

    Task<IEnumerable<Warehouse>> GetWarehouses(
        string cityId,
        string cityName);

    Task<IEnumerable<Warehouse>> GetWarehousesByCityName(string cityName);
}