using NovaPoshtaApi;

namespace S148.Backend.Extensibility.NovaPoshta;

public class LimitedWarehouseParameters : WarehouseParameters
{
    public int Limit { get; set; }
    
    public int Page { get; set; }
    
    public string WarehouseId { get; set; }
}