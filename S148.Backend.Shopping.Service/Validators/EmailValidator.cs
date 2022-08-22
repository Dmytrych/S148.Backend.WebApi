using System.Text.RegularExpressions;

namespace S148.Backend.Shopping.Service.Validators;

public class EmailValidator : IEmailValidator
{
    public bool Validate(string email)
    {
        return Regex.Match(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").Success;
    }
}