using S148.Backend.RestApi.Extensibility.Filters;

namespace S148.Backend.Shopping.Extensibility.Models.Filters;

public class OrderDetailsFilter
{
    public CollectionFilter<int> ProductFilter { get; set; }
    
    public CollectionFilter<int> OrderFilter { get; set; }
}