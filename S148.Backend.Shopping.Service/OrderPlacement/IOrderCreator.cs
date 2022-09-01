using S148.Backend.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.OrderPlacement;

public interface IOrderCreator
{
    OperationResult<(int orderId, IReadOnlyCollection<OrderDetailsServiceModel> orderDetails)> Create(
        CustomerInfoDto customerInfo,
        IReadOnlyCollection<ProductOrderingInfo> products,
        string cityId,
        int warehouseNumber);
}