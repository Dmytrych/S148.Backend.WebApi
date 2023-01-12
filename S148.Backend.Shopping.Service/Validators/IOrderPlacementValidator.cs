using S148.Backend.Extensibility;
using S148.Backend.Shopping.Service.OrderPlacement.Dto;

namespace S148.Backend.Shopping.Service.Validators;

public interface IOrderPlacementValidator
{
    OperationResult Validate(NovaPoshtaOrderData novaPoshtaOrderData);
}