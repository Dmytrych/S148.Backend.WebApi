using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.OrderPlacement.Dto;

public interface IOrderData
{
    CustomerServiceModel CustomerModel { get; set; }
    
    IReadOnlyCollection<ProductOrderingInfo> Products { get; set; }
}