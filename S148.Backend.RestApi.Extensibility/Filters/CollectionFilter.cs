namespace S148.Backend.RestApi.Extensibility.Filters;

public class CollectionFilter<T>
{
    public IReadOnlyCollection<T> Filter { get; set; }
}