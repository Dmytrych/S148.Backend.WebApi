namespace S148.Backend.Shopping.Extensibility.Models.Filters;

public class ProductFilter
{
    public IReadOnlyCollection<int> Id { get; set; } = new List<int>();
}