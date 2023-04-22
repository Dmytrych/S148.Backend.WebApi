using ErrorOr;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Service.Validators;

internal class CustomerInfoValidator : ICustomerInfoValidator
{
    private readonly IEmailValidator emailValidator;
    private readonly IPhoneValidator phoneValidator;

    public CustomerInfoValidator(
        IEmailValidator emailValidator,
        IPhoneValidator phoneValidator)
    {
        this.emailValidator = emailValidator;
        this.phoneValidator = phoneValidator;
    }

    public ErrorOr<Created> Validate(CustomerServiceModel customerInfo)
    {
        if (customerInfo == null)
        {
            return Error.Validation("The customer information is invalid.");
        }
        
        if (!emailValidator.Validate(customerInfo.Email))
        {
            return Error.Validation($"Invalid email: {customerInfo.Email}");
        }

        var trimmedName = customerInfo.Name.Trim();
        var trimmedSurname = customerInfo.Name.Trim();
        var trimmedMiddleName = customerInfo.Name.Trim();
        if (string.IsNullOrEmpty(trimmedName) 
            || string.IsNullOrEmpty(trimmedSurname)
            || string.IsNullOrEmpty(trimmedMiddleName))
        {
            return Error.Validation("The customer name is not valid");
        }

        if (!phoneValidator.Validate(customerInfo.PhoneNumber))
        {
            return Error.Validation("The phone number is not valid");
        }

        return Result.Created;
    }
}