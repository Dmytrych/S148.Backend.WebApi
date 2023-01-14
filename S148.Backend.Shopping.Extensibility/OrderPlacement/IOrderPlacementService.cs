using S148.Backend.Extensibility;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Extensibility.OrderPlacement;

public interface IOrderPlacementService<in TDeliveryData>
    where TDeliveryData : IOrderData
{
    Task<OperationResult<OrderPlacementResponse>> CreateAsync(TDeliveryData orderData);
}