using ErrorOr;
using S148.Backend.Shopping.Extensibility.Models.Service;
namespace S148.Backend.Shopping.Service.Validators;

public interface ICustomerInfoValidator
{
    ErrorOr<Created> Validate(CustomerServiceModel customerInfo);
}