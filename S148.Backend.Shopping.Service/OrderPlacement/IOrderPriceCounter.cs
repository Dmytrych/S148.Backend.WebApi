using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Service.OrderPlacement;

internal interface IOrderPriceCounter
{
    decimal GetTotalPrice(IReadOnlyCollection<OrderDetailsServiceModel> orderDetails);
}