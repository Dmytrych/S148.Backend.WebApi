using System.Text.RegularExpressions;

namespace S148.Backend.Shopping.Service.Validators;

internal class PhoneValidator : IPhoneValidator
{
    private const string UkraineCountryCode = "+380";
    private const int PhoneNumberLength = 12;

    public bool Validate(string phoneNumberString)
        => phoneNumberString.StartsWith(UkraineCountryCode) && Regex.IsMatch(phoneNumberString, @"^\\d{9}$");
}