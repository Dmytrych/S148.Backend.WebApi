namespace S148.Backend.Extensibility.Messaging;

public class DefaultProcessResult : IProcessResult
{
    public DefaultProcessResult(int processResultCode)
    {
        Code = processResultCode;
    }

    public int Code { get; }

    public virtual object ResultData => null;
}