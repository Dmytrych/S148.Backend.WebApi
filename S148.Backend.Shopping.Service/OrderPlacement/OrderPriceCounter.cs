using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Service.OrderPlacement;

internal class OrderPriceCounter : IOrderPriceCounter
{
    public decimal GetTotalPrice(IReadOnlyCollection<OrderDetailsServiceModel> orderDetails)
    {
        decimal total = 0;

        foreach (var detail in orderDetails)
        {
            total = detail.Quantity * detail.UnitPrice;
        }

        return total;
    }
}