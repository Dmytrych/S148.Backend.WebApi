using S148.Backend.Extensibility;
using S148.Backend.NovaPoshta.Extensibility.Repositories;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.OrderPlacement;

public class NovaPoshtaDeliveryInfoFactory : INovaPoshtaDeliveryInfoFactory
{
    private readonly INovaPoshtaInfoRepository novaPoshtaInfoRepository;
    
    public NovaPoshtaDeliveryInfoFactory(INovaPoshtaInfoRepository novaPoshtaInfoRepository)
    {
        this.novaPoshtaInfoRepository = novaPoshtaInfoRepository;
    }
    
    public async Task<OperationResult<NovaPoshtaDeliveryInfoServiceModel>> CreateAsync(NovaPoshtaOrderData deliveryData)
    {
        var foundCity = await novaPoshtaInfoRepository.GetCityByIdAsync(deliveryData.CityGuidRef);
        if (!foundCity.IsValid || foundCity.Result == null)
        {
            throw new ArgumentException();
        }

        var foundWarehouse =
            await novaPoshtaInfoRepository.GetWarehouseByNumberAsync(foundCity.Result.Ref, deliveryData.WarehouseNumber);
        if (!foundWarehouse.IsValid || foundWarehouse.Result == null)
        {
            throw new AggregateException();
        }

        return new OperationResult<NovaPoshtaDeliveryInfoServiceModel>(new NovaPoshtaDeliveryInfoServiceModel
        {
            AreaName = foundCity.Result.AreaDescription,
            AreaRef = foundCity.Result.Area,
            CityName = foundCity.Result.Description,
            CityRef = foundCity.Result.Ref,
            CityType = foundCity.Result.SettlementTypeDescription,
            WarehouseDescription = foundWarehouse.Result.Description,
            WarehouseNumber = foundWarehouse.Result.Number
        });
    }
}