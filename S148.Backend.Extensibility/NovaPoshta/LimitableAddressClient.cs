using NovaPoshtaApi;
using S148.Backend.Extensibility.NovaPoshta.Models;
using S148.Backend.Extensibility.NovaPoshta.ParameterCreators;

namespace S148.Backend.Extensibility.NovaPoshta;

public class LimitableAddressClient : ApiClient, ILimitableAddressClient
{
    private readonly IParameterCreator<LimitedWarehouseParameters, WarehouseFilter> warehouseParameterCreator;
    private readonly IParameterCreator<LimitedCityParameters, CityFilter> cityParameterCreator;
    
    public LimitableAddressClient(
        IApiConnection connection,
        IParameterCreator<LimitedWarehouseParameters, WarehouseFilter> warehouseParameterCreator,
        IParameterCreator<LimitedCityParameters, CityFilter> cityParameterCreator)
        : base(connection)
    {
        this.warehouseParameterCreator = warehouseParameterCreator;
        this.cityParameterCreator = cityParameterCreator;
    }

    //This method was left only because the original library interface has it
    [Obsolete("Do not use this method. It loads a giant amount of data from an external API and always fails with timeout")]
    public async Task<IEnumerable<City>> GetCities()
        => throw new NotImplementedException("Do not use this method");

    public async Task<IEnumerable<City>> GetCities(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof (id));
        return await GetCities(new CityFilter
        {
            CityId = id
        });
    }

    public async Task<IEnumerable<City>> GetCitiesByName(string name)
    {
        if (name == null)
            throw new ArgumentNullException(nameof (name));
        return await GetCities(new CityFilter
        {
            CityName = name
        });
    }

    public async Task<IEnumerable<Area>> GetAreas()
    {
        var request = new AreaRequest(ApiConnection.ApiKey);
        return await ApiConnection.Get<IEnumerable<Area>, string[], AreaParameters>(request);
    }

    //This method was left only because the original library interface has it
    [Obsolete("Do not use this method. It loads a giant amount of data from an external API and always fails with timeout")]
    public Task<IEnumerable<Warehouse>> GetWarehouses()
        => throw new NotImplementedException("Do not use this method");

    public async Task<IEnumerable<Warehouse>> GetWarehouses(string cityId)
        => await GetWarehouses(new WarehouseFilter
        {
            CityId = cityId
        });

    public async Task<IEnumerable<Warehouse>> GetWarehouses(string cityId, string cityName)
        => await GetWarehouses(new WarehouseFilter
        {
            CityId = cityId
        });

    public async Task<IEnumerable<Warehouse>> GetWarehouses(WarehouseFilter filter)
    {
        if (filter == null)
        {
            throw new ArgumentNullException("Invalid input data");
        }

        var parameters = warehouseParameterCreator.Create(filter);

        var request = new LimitedWarehouseRequest(parameters, ApiConnection.ApiKey);
        return await ApiConnection.Get<IEnumerable<Warehouse>, Info, LimitedWarehouseParameters>(request);
    }

    public async Task<IEnumerable<Warehouse>> GetWarehousesByCityName(string cityName)
        => await GetWarehouses("", cityName);

    public async Task<IEnumerable<City>> GetCities(CityFilter cityFilter)
    {
        var request = new LimitedCityRequest(cityParameterCreator.Create(cityFilter), ApiConnection.ApiKey);
        return await ApiConnection.Get<IEnumerable<City>, Info, LimitedCityParameters>(request);
    }
}