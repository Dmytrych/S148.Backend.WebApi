using S148.Backend.RestApi.Extensibility.Filters;

namespace S148.Backend.Shopping.Extensibility.Models.Filters;

public class DeliveryInfoFilter
{
    public CollectionFilter<int> IdFilter { get; set; }
}