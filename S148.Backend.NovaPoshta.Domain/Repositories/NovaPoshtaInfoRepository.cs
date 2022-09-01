using NovaPoshtaApi;
using S148.Backend.Extensibility;
using S148.Backend.Extensibility.NovaPoshta;
using S148.Backend.Extensibility.NovaPoshta.Models;
using S148.Backend.NovaPoshta.Extensibility.Repositories;

namespace S148.Backend.NovaPoshta.Domain.Repositories;

public class NovaPoshtaInfoRepository : INovaPoshtaInfoRepository
{
    private readonly ICustomNovaPoshtaClient novaPoshtaClient;
    
    public NovaPoshtaInfoRepository(ICustomNovaPoshtaClient novaPoshtaClient)
    {
        this.novaPoshtaClient = novaPoshtaClient;
    }

    public async Task<IReadOnlyCollection<City>> GetCitiesByName(string name)
        => (await novaPoshtaClient.Address.GetCitiesByName(name)).ToList();

    public async Task<IReadOnlyCollection<Warehouse>> GetWarehouses(string cityId, string cityName, int limit)
        => (await novaPoshtaClient.Address.GetWarehouses(new WarehouseFilter
        {
            CityId = cityId,
            CityName = cityName,
            Limit = limit,
            Page = 1
        })).ToList();

    public async Task<OperationResult<Warehouse>> GetWarehouseByNumberAsync(string cityId, string cityName, int warehouseNumber)
    {
        var warehouses = (await novaPoshtaClient.Address.GetWarehouses(new WarehouseFilter
        {
            WarehouseId = warehouseNumber.ToString(),
            CityId = cityId,
            Limit = 1,
            Page = 1,
            CityName = cityName
        })).ToList();

        if (warehouses.Any())
        {
            return new OperationResult<Warehouse>(warehouses.First());
        }

        return new OperationResult<Warehouse>(new List<string>());
    }

    public async Task<OperationResult<City>> GetCityByIdAsync(string cityId)
    {
        var cities = (await novaPoshtaClient.Address.GetCities(new CityFilter
        {
            CityId = cityId
        })).ToList();

        if (cities.Any())
        {
            return new OperationResult<City>(cities.First());
        }
        
        return new OperationResult<City>(new List<string>());
    }

    public async Task<OperationResult<Area>> GetAreaByIdAsync(string areaId)
    {
        var area = (await novaPoshtaClient.Address.GetAreas()).FirstOrDefault(area => area.Ref == areaId);
        if (area != null)
        {
            return new OperationResult<Area>(area);
        }

        return new OperationResult<Area>(new List<string>());
    }
}