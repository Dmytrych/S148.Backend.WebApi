using S148.Backend.NovaPoshta.Extensibility.Services;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Service.OrderPlacement.Dto;

namespace S148.Backend.Shopping.Service.OrderPlacement;

public class NovaPoshtaDeliveryInfoFactory : INovaPoshtaDeliveryInfoFactory
{
    private readonly IDeliveryInfoService deliveryInfoService;
    
    public NovaPoshtaDeliveryInfoFactory(IDeliveryInfoService deliveryInfoService)
    {
        this.deliveryInfoService = deliveryInfoService;
    }
    
    public NovaPoshtaDeliveryInfoServiceModel Create(NovaPoshtaOrderData deliveryData)
    {
        var novaPoshtaDeliveryInfoServiceModel = new NovaPoshtaDeliveryInfoServiceModel();
        
        deliveryInfoService.G
        
        deliveryInfoService.GetWarehouseByNumberAsync(deliveryData.CityGuidRef.ToString(),)
    }
}