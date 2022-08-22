using S148.Backend.Extensibility;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.Validators;

public class CustomerInfoValidator
{
    private readonly IEmailValidator emailValidator;

    public CustomerInfoValidator(IEmailValidator emailValidator)
    {
        this.emailValidator = emailValidator;
    }

    public OperationResult Validate(CustomerInfoDto customerInfo)
    {
        if (emailValidator.Validate(customerInfo.Email))
        {
            throw new ArgumentException();
        }

        if()
    }
}