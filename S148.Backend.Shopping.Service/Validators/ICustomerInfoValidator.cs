using S148.Backend.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Service;
namespace S148.Backend.Shopping.Service.Validators;

public interface ICustomerInfoValidator
{
    OperationResult Validate(CustomerServiceModel customerInfo);
}