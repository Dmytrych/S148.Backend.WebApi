using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

public class NovaPoshtaOrderData : IOrderData
{
    public NovaPoshtaOrderData(
        int warehouseNumber,
        Guid cityGuidRef,
        CustomerServiceModel customerModel,
        IReadOnlyCollection<ProductOrderingInfo> products)
    {
        WarehouseNumber = warehouseNumber;
        CityGuidRef = cityGuidRef;
        CustomerModel = customerModel;
        Products = products;
    }
    
    public int WarehouseNumber { get; set; }

    public Guid CityGuidRef { get; set; }

    public CustomerServiceModel CustomerModel { get; set; }

    public IReadOnlyCollection<ProductOrderingInfo> Products { get; set; }
}