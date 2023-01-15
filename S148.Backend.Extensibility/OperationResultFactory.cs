using S148.Backend.Extensibility.Messaging;

namespace S148.Backend.Extensibility;

public class OperationResultFactory : IOperationResultFactory
{
    private readonly IProcessResultCodeRegistry processResultCodeRegistry;
    
    public OperationResultFactory(IProcessResultCodeRegistry processResultCodeRegistry)
    {
        this.processResultCodeRegistry = processResultCodeRegistry;
    }
    
    public OperationResult FromStatusCode(string processResultCodeName)
    {
        var code = GetProcessResultCode(processResultCodeName);
        return new OperationResult(
            new DefaultProcessResult(code));
    }

    public OperationResult FromStatusCode<TProcessResultData>(string processResultCodeName, TProcessResultData processResultData)
    {
        var code = GetProcessResultCode(processResultCodeName);
        return new OperationResult(
            new ParameterProcessResult<TProcessResultData>(code, processResultData));
    }
    
    public OperationResult<TOperationResultData> FromStatusCode<TOperationResultData>(string processResultCodeName)
    {
        var code = GetProcessResultCode(processResultCodeName);
        return new OperationResult<TOperationResultData>(
            new DefaultProcessResult(code));
    }
    
    public OperationResult<TOperationResultData> FromStatusCode<TOperationResultData, TProcessResultData>(string processResultCodeName, TProcessResultData processResultData)
    {
        var code = GetProcessResultCode(processResultCodeName);
        return new OperationResult<TOperationResultData>(
            new ParameterProcessResult<TProcessResultData>(code, processResultData));
    }

    private int GetProcessResultCode(string processResultCodeName)
        => processResultCodeRegistry.GetCode(processResultCodeName);
}