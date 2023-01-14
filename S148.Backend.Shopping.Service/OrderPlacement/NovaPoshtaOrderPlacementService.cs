using S148.Backend.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;
using S148.Backend.Shopping.Extensibility.Repositories;
using S148.Backend.Shopping.Service.Repositories;
using S148.Backend.Shopping.Service.Validators;

namespace S148.Backend.Shopping.Service.OrderPlacement;

internal class NovaPoshtaOrderPlacementService : IOrderPlacementService<NovaPoshtaOrderData>
{
    private readonly INovaPoshtaDeliveryInfoFactory novaPoshtaDeliveryInfoFactory;

    private readonly ICustomerInfoValidator customerInfoValidator;

    private readonly IOrderContentValidator orderContentValidator;

    private readonly ICustomerCrudRepository customerCrudRepository;

    private readonly INovaPoshtaDeliveryInfoCrudRepository novaPoshtaDeliveryInfoCrudRepository;

    private readonly IOrderCrudRepository orderRepository;

    private readonly IProductRepository productRepository;

    private readonly IOrderDetailsCrudRepository orderDetailsRepository;

    private readonly IOrderPriceCounter orderPriceCounter;

    private readonly IDeliveryInfoCrudRepository deliveryInfoCrudRepository;

    public NovaPoshtaOrderPlacementService(
        INovaPoshtaDeliveryInfoFactory novaPoshtaDeliveryInfoFactory,
        ICustomerInfoValidator customerInfoValidator,
        IOrderContentValidator orderContentValidator,
        ICustomerCrudRepository customerCrudRepository,
        INovaPoshtaDeliveryInfoCrudRepository novaPoshtaDeliveryInfoCrudRepository,
        IOrderCrudRepository orderRepository,
        IProductRepository productRepository,
        IOrderDetailsCrudRepository orderDetailsRepository,
        IOrderPriceCounter orderPriceCounter,
        IDeliveryInfoCrudRepository deliveryInfoCrudRepository)
    {
        this.novaPoshtaDeliveryInfoFactory = novaPoshtaDeliveryInfoFactory;
        this.customerInfoValidator = customerInfoValidator;
        this.orderContentValidator = orderContentValidator;
        this.customerCrudRepository = customerCrudRepository;
        this.novaPoshtaDeliveryInfoCrudRepository = novaPoshtaDeliveryInfoCrudRepository;
        this.orderRepository = orderRepository;
        this.productRepository = productRepository;
        this.orderDetailsRepository = orderDetailsRepository;
        this.orderPriceCounter = orderPriceCounter;
        this.deliveryInfoCrudRepository = deliveryInfoCrudRepository;
    }
    
    public async Task<OperationResult<OrderPlacementResponse>> CreateAsync(NovaPoshtaOrderData orderData)
    {
        var customerInfoValidationResult = customerInfoValidator.Validate(orderData.CustomerModel);
        if (!customerInfoValidationResult.IsValid)
        {
            throw new ArgumentException();
        }

        var productValidationResult = orderContentValidator.Validate(orderData.Products);
        if (!productValidationResult.IsValid)
        {
            throw new ArgumentException();
        }
        
        var createdCustomer = customerCrudRepository.Create(orderData.CustomerModel);

        var deliveryInfoCreationResult = await novaPoshtaDeliveryInfoFactory.CreateAsync(orderData);
        if (!deliveryInfoCreationResult.IsValid)
        {
            throw new ArgumentException();
        }
        
        var createdNovaPoshtaDeliveryInfo = novaPoshtaDeliveryInfoCrudRepository.Create(deliveryInfoCreationResult.Result);

        var createdDeliveryInfo = deliveryInfoCrudRepository.Create(new DeliveryInfoServiceModel
        {
            NovaPoshtaDeliveryInfoId = createdNovaPoshtaDeliveryInfo.Id
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
        
        return new OperationResult<OrderPlacementResponse>(new OrderPlacementResponse
        {
            OrderId = createdOrder.Id,
            TotalPrice = orderPriceCounter.GetTotalPrice(createdOrderDetails)
        });
    }
}