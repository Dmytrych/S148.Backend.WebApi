namespace S148.Backend.Extensibility.Messaging;

public interface IProcessResult
{
    int Code { get; }
    
    object ResultData { get; }
}