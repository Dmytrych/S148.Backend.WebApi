using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.OrderPlacement;

public interface INovaPoshtaDeliveryInfoFactory : IDeliveryInfoFactory<NovaPoshtaDeliveryInfoServiceModel, NovaPoshtaOrderData>
{
}