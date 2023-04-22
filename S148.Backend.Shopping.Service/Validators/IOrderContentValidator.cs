using ErrorOr;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.Validators;

public interface IOrderContentValidator
{
    ErrorOr<Success> Validate(IReadOnlyCollection<ProductOrderingInfo> products);
}