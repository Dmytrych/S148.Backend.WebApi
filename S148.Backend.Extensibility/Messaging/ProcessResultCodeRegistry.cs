namespace S148.Backend.Extensibility.Messaging;

public class ProcessResultCodeRegistry : IProcessResultCodeRegistry
{
    public IReadOnlyDictionary<string, int> ProcessResultCodeMapping { get; private set; }

    public ProcessResultCodeRegistry(IReadOnlyDictionary<string, int> processResultCodeMapping)
    {
        ProcessResultCodeMapping = processResultCodeMapping;
    }

    public int GetCode(string codeName)
        => ProcessResultCodeMapping[codeName];
}