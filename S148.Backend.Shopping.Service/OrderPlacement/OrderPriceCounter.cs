using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Service.OrderPlacement;

public class OrderPriceCounter
{
    public float GetTotalPrice(IReadOnlyCollection<OrderDetailsServiceModel> orderDetails)
    {
        decimal total = 0;

        foreach (var detail in orderDetails)
        {
            total = detail.Quantity * detail.UnitPrice;
        }
    }
}