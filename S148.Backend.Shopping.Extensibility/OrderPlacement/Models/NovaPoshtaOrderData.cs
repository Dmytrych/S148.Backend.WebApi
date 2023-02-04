using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

public class NovaPoshtaOrderData : IOrderData
{
    public NovaPoshtaOrderData(
        string description,
        CustomerServiceModel customerModel,
        IReadOnlyCollection<ProductOrderingInfo> products)
    {
        Description = description;
        CustomerModel = customerModel;
        Products = products;
    }
    
    public string Description { get; set; }

    public CustomerServiceModel CustomerModel { get; set; }

    public IReadOnlyCollection<ProductOrderingInfo> Products { get; set; }
}