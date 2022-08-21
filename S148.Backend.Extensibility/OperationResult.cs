using System.Text.Json.Serialization;

namespace S148.Backend.Extensibility;

public class OperationResult<TResult> : OperationResult
{
    public OperationResult(TResult result) 
        : base(true)
    {
        Result = result;
    }

    public OperationResult(IReadOnlyCollection<string> errorMessageCodes) 
        : base(errorMessageCodes)
    {
    }

    public TResult? Result { get; }
}

public class OperationResult
{
    public OperationResult(bool isValid)
    {
        IsValid = isValid;
    }
    
    public OperationResult(IReadOnlyCollection<string> errorMessageCodes)
    {
        IsValid = false;
        ErrorMessageCodes = errorMessageCodes;
    }

    [JsonIgnore]
    public bool IsValid { get; }

    public IReadOnlyCollection<string> ErrorMessageCodes { get; } = new List<string>();
}