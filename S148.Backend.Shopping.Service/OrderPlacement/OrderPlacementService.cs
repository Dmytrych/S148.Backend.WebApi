using S148.Backend.Shopping.Extensibility.OrderPlacement;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.OrderPlacement;

internal class OrderPlacementService : IOrderPlacementService
{
    public Guid Create(CustomerInfoDto customerInfo, IReadOnlyCollection<ProductOrderingInfo> products)
    {

    }
}