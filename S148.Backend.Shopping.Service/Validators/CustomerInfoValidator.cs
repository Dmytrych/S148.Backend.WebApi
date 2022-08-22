using S148.Backend.Extensibility;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.Validators;

internal class CustomerInfoValidator : ICustomerInfoValidator
{
    private readonly IEmailValidator emailValidator;
    private readonly IPhoneValidator phoneValidator;

    public CustomerInfoValidator(IEmailValidator emailValidator, IPhoneValidator phoneValidator)
    {
        this.emailValidator = emailValidator;
        this.phoneValidator = phoneValidator;
    }

    public OperationResult Validate(CustomerInfoDto customerInfo)
    {
        if (!emailValidator.Validate(customerInfo.Email))
        {
            throw new ArgumentException();
        }

        var trimmedName = customerInfo.Name.Trim();
        var trimmedSurname = customerInfo.Name.Trim();
        var trimmedMiddleName = customerInfo.Name.Trim();
        if (!string.IsNullOrEmpty(trimmedName) 
            || !string.IsNullOrEmpty(trimmedSurname)
            || !string.IsNullOrEmpty(trimmedMiddleName))
        {
            throw new ArgumentException();
        }

        if (!phoneValidator.Validate(customerInfo.PhoneNumber))
        {
            throw new ArgumentException();
        }

        return new OperationResult(true);
    }
}