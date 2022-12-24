namespace S148.Backend.Extensibility.NovaPoshta.Models;

public class WarehouseFilter
{
    public int? WarehouseId { get; set; }
    
    public string CityName { get; set; }
    
    public string CityId { get; set; }
    
    public int Page { get; set; }
    
    public int Limit { get; set; }
}