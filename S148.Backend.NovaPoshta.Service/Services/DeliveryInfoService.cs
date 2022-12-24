using NovaPoshtaApi;
using S148.Backend.Extensibility;
using S148.Backend.NovaPoshta.Extensibility.Repositories;
using S148.Backend.NovaPoshta.Extensibility.Services;

namespace S148.Backend.NovaPoshta.Service.Services;

public class DeliveryInfoService : IDeliveryInfoService
{
    private readonly INovaPoshtaInfoRepository infoRepository;
    
    public DeliveryInfoService(INovaPoshtaInfoRepository infoRepository)
    {
        this.infoRepository = infoRepository;
    }
    
    public async Task<IReadOnlyCollection<City>> GetCitiesAsync(string nameFilter)
    {
        if (nameFilter.Length < 3)
        {
            return new List<City>();
        }

        return (await infoRepository.GetCitiesByName(nameFilter)).ToList();
    }

    public async Task<OperationResult<Warehouse>> GetWarehouseByNumberAsync(string cityId, string cityName, int warehouseId)
        => await infoRepository.GetWarehouseByNumberAsync(cityId, cityName, warehouseId);

    public async Task<OperationResult<Area>> GetArea(string areaGuidRef)
        => await infoRepository.GetAreaByIdAsync(areaGuidRef);
}