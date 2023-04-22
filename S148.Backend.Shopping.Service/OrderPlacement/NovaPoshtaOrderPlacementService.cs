using ErrorOr;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;
using S148.Backend.Shopping.Extensibility.Repositories;
using S148.Backend.Shopping.Service.Repositories;
using S148.Backend.Shopping.Service.Validators;

namespace S148.Backend.Shopping.Service.OrderPlacement;

internal class NovaPoshtaOrderPlacementService : IOrderPlacementService<NovaPoshtaOrderData>
{
    private readonly ICustomerInfoValidator customerInfoValidator;

    private readonly IOrderContentValidator orderContentValidator;

    private readonly ICustomerCrudRepository customerCrudRepository;

    private readonly IOrderCrudRepository orderRepository;

    private readonly IProductRepository productRepository;

    private readonly IOrderDetailsCrudRepository orderDetailsRepository;

    private readonly IOrderPriceCounter orderPriceCounter;

    private readonly IDeliveryInfoCrudRepository deliveryInfoCrudRepository;

    public NovaPoshtaOrderPlacementService(
        ICustomerInfoValidator customerInfoValidator,
        IOrderContentValidator orderContentValidator,
        ICustomerCrudRepository customerCrudRepository,
        IOrderCrudRepository orderRepository,
        IProductRepository productRepository,
        IOrderDetailsCrudRepository orderDetailsRepository,
        IOrderPriceCounter orderPriceCounter,
        IDeliveryInfoCrudRepository deliveryInfoCrudRepository)
    {
        this.customerInfoValidator = customerInfoValidator;
        this.orderContentValidator = orderContentValidator;
        this.customerCrudRepository = customerCrudRepository;
        this.orderRepository = orderRepository;
        this.productRepository = productRepository;
        this.orderDetailsRepository = orderDetailsRepository;
        this.orderPriceCounter = orderPriceCounter;
        this.deliveryInfoCrudRepository = deliveryInfoCrudRepository;
    }
    
    public ErrorOr<OrderPlacementResponse> Create(NovaPoshtaOrderData orderData)
    {
        var errors = new List<Error>();
        
        var customerInfoValidationResult = customerInfoValidator.Validate(orderData.CustomerModel);
        errors.AddRange(customerInfoValidationResult.Errors);

        if (customerInfoValidationResult.IsError)
        {
            return errors;
        }

        var productValidationResult = orderContentValidator.Validate(orderData.Products);
        errors.AddRange(productValidationResult.Errors);

        if (productValidationResult.IsError)
        {
            return errors;
        }
        
        var createdCustomer = customerCrudRepository.Create(orderData.CustomerModel);

        var createdDeliveryInfo = deliveryInfoCrudRepository.Create(new DeliveryInfoServiceModel
        {
            Description = orderData.Description
        });

        var order = new OrderServiceModel
        {
            CustomerId = createdCustomer.Id,
            DeliveryInfoId = createdDeliveryInfo.Id
        };
        var createdOrder = orderRepository.Create(order);

        var createdOrderDetails = new List<OrderDetailsServiceModel>();
        foreach (var product in orderData.Products)
        {
            var orderDetails = new OrderDetailsServiceModel
            {
                OrderId = createdOrder.Id,
                ProductId = product.ProductId,
                Quantity = product.Quantity,
                UnitPrice = productRepository.GetPrice(product.ProductId) ??
                            throw new ArgumentException("Product was not found")
            };

            createdOrderDetails.Add(orderDetailsRepository.Create(orderDetails));
        }

        return new OrderPlacementResponse
        {
            OrderId = createdOrder.Id,
            TotalPrice = orderPriceCounter.GetTotalPrice(createdOrderDetails)
        };
    }
}