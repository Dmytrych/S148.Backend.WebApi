namespace S148.Backend.Shopping.Service.OrderPlacement;

public interface IDeliveryInfoFactory<TDeliveryInfo, TDeliveryData>
{
    public TDeliveryInfo Create(TDeliveryData deliveryData);
}