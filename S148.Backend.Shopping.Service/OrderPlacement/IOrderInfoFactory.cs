using ErrorOr;

namespace S148.Backend.Shopping.Service.OrderPlacement;

public interface IDeliveryInfoFactory<TDeliveryInfo, in TDeliveryData>
{
    public Task<ErrorOr<TDeliveryInfo>> CreateAsync(TDeliveryData deliveryData);
}