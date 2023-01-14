using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.WebApi.Controllers.Dto;

public class OrderPlacementRequestModel
{
    public CustomerInfoDto CustomerInfo { get; set; }

    public IReadOnlyCollection<ProductOrderingInfo> Products { get; set; }
    
    public int WarehouseNumber { get; set; }
    
    public string CityGuidRef { get; set; }
}