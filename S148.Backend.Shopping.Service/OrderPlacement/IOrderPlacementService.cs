using S148.Backend.Shopping.Service.OrderPlacement.Dto;

namespace S148.Backend.Shopping.Service.OrderPlacement;

public interface IOrderPlacementService<TDeliveryData>
    where TDeliveryData : IOrderData
{
    
}