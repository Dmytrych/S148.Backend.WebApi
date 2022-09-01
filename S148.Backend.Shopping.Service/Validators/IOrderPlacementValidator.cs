using S148.Backend.Extensibility;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.Validators;

public interface IOrderPlacementValidator
{
    OperationResult Validate(CustomerInfoDto customerInfo, IReadOnlyCollection<ProductOrderingInfo> products, string cityId, int warehouseNumber);
}