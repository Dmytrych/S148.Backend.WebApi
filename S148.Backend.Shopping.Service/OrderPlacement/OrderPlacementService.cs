using AutoMapper;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;
using S148.Backend.Shopping.Extensibility.Repositories;
using S148.Backend.Shopping.Service.Repositories;
using S148.Backend.Shopping.Service.Validators;

namespace S148.Backend.Shopping.Service.OrderPlacement;

internal class OrderPlacementService : IOrderPlacementService
{
    private readonly ICustomerCrudRepository customerRepository;
    private readonly IOrderCrudRepository orderRepository;
    private readonly IOrderDetailsCrudRepository orderDetailsRepository;
    private readonly ICustomerInfoValidator customerInfoValidator;
    private readonly IProductRepository productRepository;
    private readonly IOrderPriceCounter orderPriceCounter;
    private readonly IMapper mapper;

    public OrderPlacementService(
        ICustomerCrudRepository customerRepository,
        IOrderCrudRepository orderRepository,
        IOrderDetailsCrudRepository orderDetailsRepository,
        ICustomerInfoValidator customerInfoValidator,
        IProductRepository productRepository,
        IOrderPriceCounter orderPriceCounter,
        IMapper mapper)
    {
        this.customerRepository = customerRepository;
        this.orderRepository = orderRepository;
        this.orderDetailsRepository = orderDetailsRepository;
        this.customerInfoValidator = customerInfoValidator;
        this.productRepository = productRepository;
        this.orderPriceCounter = orderPriceCounter;
        this.mapper = mapper;
    }

    public OrderPlacementResponse Create(CustomerInfoDto customerInfo, IReadOnlyCollection<ProductOrderingInfo> products)
    {
        if (!products.Any())
        {
            throw new ArgumentException();
        }

        var customerValidationResult = customerInfoValidator.Validate(customerInfo);

        if (!customerValidationResult.IsValid)
        {
            throw new ArgumentException();
        }

        var allProductIds = productRepository.GetAll();
        if (products.All(product => allProductIds.Contains(product.ProductId)))
        {
            throw new ArgumentException();
        }

        if (products.DistinctBy(p => p.ProductId).Count() != products.Count)
        {
            throw new ArgumentException();
        }

        var customer = mapper.Map<CustomerInfoDto, CustomerServiceModel>(customerInfo);

        var customerModel = customerRepository.Create(customer);

        var order = new OrderServiceModel
        {
            CustomerId = customerModel.Id
        };
        var orderModel = orderRepository.Create(order);

        var createdOrderDetails = new List<OrderDetailsServiceModel>();
        foreach (var product in products)
        {
            var orderDetails = new OrderDetailsServiceModel
            {
                OrderId = orderModel.Id,
                ProductId = product.ProductId,
                Quantity = product.Quantity,
                UnitPrice = productRepository.GetPrice(product.ProductId) ??
                            throw new ArgumentException("Product was not found")
            };

            createdOrderDetails.Add(orderDetailsRepository.Create(orderDetails));
        }

        var totalPrice = orderPriceCounter.GetTotalPrice(createdOrderDetails);

        return new OrderPlacementResponse
        {
            OrderId = orderModel.Id,
            TotalPrice = totalPrice
        };
    }
}