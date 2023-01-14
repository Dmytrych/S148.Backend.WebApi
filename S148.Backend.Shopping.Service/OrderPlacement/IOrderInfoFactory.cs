using S148.Backend.Extensibility;

namespace S148.Backend.Shopping.Service.OrderPlacement;

public interface IDeliveryInfoFactory<TDeliveryInfo, in TDeliveryData>
{
    public Task<OperationResult<TDeliveryInfo>> CreateAsync(TDeliveryData deliveryData);
}