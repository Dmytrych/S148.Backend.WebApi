using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.OrderPlacement.Dto;

public class NovaPoshtaOrderData : IOrderData
{
    public NovaPoshtaOrderData(
        int warehouseNumber,
        Guid warehouseGuidRef,
        Guid cityGuidRef,
        CustomerServiceModel customerModel,
        IReadOnlyCollection<ProductOrderingInfo> products)
    {
        WarehouseNumber = warehouseNumber;
        WarehouseGuidRef = warehouseGuidRef;
        CityGuidRef = cityGuidRef;
        CustomerModel = customerModel;
        Products = products;
    }
    
    public int WarehouseNumber { get; set; }

    public Guid WarehouseGuidRef { get; set; }

    public Guid CityGuidRef { get; set; }

    public CustomerServiceModel CustomerModel { get; set; }

    public IReadOnlyCollection<ProductOrderingInfo> Products { get; set; }
}