using NovaPoshtaApi;

namespace S148.Backend.Extensibility.NovaPoshta;

public class LimitedWarehouseRequest : AddressRequest<LimitedWarehouseParameters>
{
    public LimitedWarehouseRequest(LimitedWarehouseParameters warehouseParameters, string apiKey)
        : base(apiKey, "getWarehouses")
    {
        methodProperties = warehouseParameters;
    }
}