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

    public async Task<OperationResult<Warehouse>> GetWarehouseByNumberAsync(Guid cityGuidRef, int warehouseNumber)
    {
        var warehouses = (await novaPoshtaClient.Address.GetWarehouses(new WarehouseFilter
        {
            WarehouseId = warehouseNumber,
            CityId = cityGuidRef.ToString(),
            Limit = 100,
            Page = 1
        })).ToList();

        var foundWarehouse = warehouses.FirstOrDefault(warehouse => warehouse.Number == warehouseNumber);
        if (warehouses.Any() && foundWarehouse != null)
        {
            return new OperationResult<Warehouse>(foundWarehouse);
        }

        return new OperationResult<Warehouse>();
    }

    public async Task<OperationResult<City>> GetCityByIdAsync(Guid cityGuidRef)
    {
        var cities = (await novaPoshtaClient.Address.GetCities(new CityFilter
        {
            CityId = cityGuidRef.ToString()
        })).ToList();

        if (cities.Any())
        {
            return new OperationResult<City>(cities.First());
        }
        
        return new OperationResult<City>();
    }

    public async Task<OperationResult<Area>> GetAreaByIdAsync(Guid areaGuidRef)
    {
        var area = (await novaPoshtaClient.Address.GetAreas()).FirstOrDefault(area => area.Ref == areaGuidRef);
        if (area != null)
        {
            return new OperationResult<Area>(area);
        }

        return new OperationResult<Area>();
    }
}