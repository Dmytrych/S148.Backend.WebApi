using System.Text.Json.Serialization;
using S148.Backend.Extensibility.Messaging;

namespace S148.Backend.Extensibility;

public class OperationResult<TResult> : OperationResult
{
    public OperationResult() 
        : base(false)
    {
    }
    
    public OperationResult(TResult result) 
        : base(true)
    {
        Result = result;
    }

    public OperationResult(IReadOnlyCollection<IProcessResult> processResults) 
        : base(processResults)
    {
    }

    public OperationResult(IProcessResult processResult)
        : base(processResult)
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
    
    public OperationResult(IReadOnlyCollection<IProcessResult> processResults)
    {
        IsValid = false;
        ProcessResults = processResults;
    }
    
    public OperationResult(IProcessResult processResult)
    {
        IsValid = false;
        ProcessResults = new [] { processResult };
    }

    [JsonIgnore]
    public bool IsValid { get; }

    public IReadOnlyCollection<IProcessResult> ProcessResults { get; } = new List<IProcessResult>();
}