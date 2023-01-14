using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

public interface IOrderData
{
    CustomerServiceModel CustomerModel { get; set; }
    
    IReadOnlyCollection<ProductOrderingInfo> Products { get; set; }
}