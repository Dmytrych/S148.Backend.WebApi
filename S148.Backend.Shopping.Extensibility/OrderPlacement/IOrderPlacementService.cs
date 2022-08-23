using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Extensibility.OrderPlacement;

public interface IOrderPlacementService
{
    OrderPlacementResponse Create(CustomerInfoDto customerInfo, IReadOnlyCollection<ProductOrderingInfo> products);
}