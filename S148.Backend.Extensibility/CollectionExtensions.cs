namespace S148.Backend.Extensibility;

public static class CollectionExtensions
{
    public static bool IsNullOrEmpty<TContent>(this IEnumerable<TContent> enumerable)
        => enumerable == null || !enumerable.Any();
}