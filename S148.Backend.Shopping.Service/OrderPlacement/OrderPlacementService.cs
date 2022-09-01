using S148.Backend.Shopping.Extensibility.OrderPlacement;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;
using S148.Backend.Shopping.Service.Validators;

namespace S148.Backend.Shopping.Service.OrderPlacement;

internal class OrderPlacementService : IOrderPlacementService
{
    private readonly IOrderPriceCounter orderPriceCounter;
    private readonly IOrderPlacementValidator orderPlacementValidator;
    private readonly IOrderCreator orderCreator;

    public OrderPlacementService(
        IOrderPriceCounter orderPriceCounter,
        IOrderPlacementValidator orderPlacementValidator,
        IOrderCreator orderCreator)
    {
        this.orderPriceCounter = orderPriceCounter;
        this.orderPlacementValidator = orderPlacementValidator;
        this.orderCreator = orderCreator;
    }

    public OrderPlacementResponse Create(CustomerInfoDto customerInfo, IReadOnlyCollection<ProductOrderingInfo> products, string cityId, int warehouseNumber)
    {
        var validationResult = orderPlacementValidator.Validate(customerInfo, products, cityId, warehouseNumber);

        if (!validationResult.IsValid)
        {
            throw new ArgumentException("Invalid input data");
        }

        var creationResult = orderCreator.Create(customerInfo, products, cityId, warehouseNumber);

        var totalPrice = orderPriceCounter.GetTotalPrice(creationResult.Result.orderDetails);

        return new OrderPlacementResponse
        {
            OrderId = creationResult.Result.orderId,
            TotalPrice = totalPrice
        };
    }
}