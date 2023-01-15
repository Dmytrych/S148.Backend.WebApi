using S148.Backend.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Service.Validators;

internal class CustomerInfoValidator : ICustomerInfoValidator
{
    private readonly IEmailValidator emailValidator;
    private readonly IPhoneValidator phoneValidator;
    private readonly IOperationResultFactory operationResultFactory;

    public CustomerInfoValidator(
        IEmailValidator emailValidator,
        IPhoneValidator phoneValidator,
        IOperationResultFactory operationResultFactory)
    {
        this.emailValidator = emailValidator;
        this.phoneValidator = phoneValidator;
        this.operationResultFactory = operationResultFactory;
    }

    public OperationResult Validate(CustomerServiceModel customerInfo)
    {
        if (customerInfo == null)
        {
            return operationResultFactory.FromStatusCode(ShoppingProcessResultCodeNames.InvalidCustomerInfo);
        }
        
        if (!emailValidator.Validate(customerInfo.Email))
        {
            return operationResultFactory.FromStatusCode(ShoppingProcessResultCodeNames.InvalidEmail);
        }

        var trimmedName = customerInfo.Name.Trim();
        var trimmedSurname = customerInfo.Name.Trim();
        var trimmedMiddleName = customerInfo.Name.Trim();
        if (string.IsNullOrEmpty(trimmedName) 
            || string.IsNullOrEmpty(trimmedSurname)
            || string.IsNullOrEmpty(trimmedMiddleName))
        {
            return operationResultFactory.FromStatusCode(ShoppingProcessResultCodeNames.InvalidCredentials);
        }

        if (!phoneValidator.Validate(customerInfo.PhoneNumber))
        {
            return operationResultFactory.FromStatusCode(ShoppingProcessResultCodeNames.InvalidPhoneNumber);
        }

        return new OperationResult(true);
    }
}