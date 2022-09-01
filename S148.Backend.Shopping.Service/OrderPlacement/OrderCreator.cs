using AutoMapper;
using S148.Backend.Extensibility;
using S148.Backend.NovaPoshta.Extensibility.Repositories;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;
using S148.Backend.Shopping.Extensibility.Repositories;
using S148.Backend.Shopping.Service.Repositories;

namespace S148.Backend.Shopping.Service.OrderPlacement;

public class OrderCreator : IOrderCreator
{
    private readonly ICustomerCrudRepository customerRepository;
    private readonly IOrderCrudRepository orderRepository;
    private readonly IOrderDetailsCrudRepository orderDetailsRepository;
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;
    private readonly INovaPoshtaInfoRepository novaPoshtaInfoRepository;
    private readonly IDeliveryInfoCrudRepository deliveryInfoCrudRepository;

    public OrderCreator(
        ICustomerCrudRepository customerRepository,
        IOrderCrudRepository orderRepository,
        IOrderDetailsCrudRepository orderDetailsRepository,
        IProductRepository productRepository,
        IMapper mapper,
        INovaPoshtaInfoRepository novaPoshtaInfoRepository,
        IDeliveryInfoCrudRepository deliveryInfoCrudRepository)
    {
        this.customerRepository = customerRepository;
        this.orderRepository = orderRepository;
        this.orderDetailsRepository = orderDetailsRepository;
        this.productRepository = productRepository;
        this.mapper = mapper;
        this.novaPoshtaInfoRepository = novaPoshtaInfoRepository;
        this.deliveryInfoCrudRepository = deliveryInfoCrudRepository;
    }
    
    public OperationResult<(int orderId, IReadOnlyCollection<OrderDetailsServiceModel> orderDetails)> Create(
        CustomerInfoDto customerInfo,
        IReadOnlyCollection<ProductOrderingInfo> products,
        string cityId,
        int warehouseNumber)
    {
        var city = novaPoshtaInfoRepository.GetCityByIdAsync(cityId).Result;

        if (!city.IsValid)
        {
            throw new ArgumentException("Could not retrieve the city");
        }
        
        var warehouse = novaPoshtaInfoRepository.GetWarehouseByNumberAsync(cityId, city.Result.Description, warehouseNumber).Result;

        if (!warehouse.IsValid)
        {
            throw new ArgumentException("Warehouse does not exist");
        }

        var area = novaPoshtaInfoRepository.GetAreaByIdAsync(city.Result.Area).Result;

        if (!area.IsValid)
        {
            throw new ArgumentException("Could not retrieve area");
        }

        var deliveryInfo = deliveryInfoCrudRepository.Create(new DeliveryInfoServiceModel
        {
            CityName = city.Result.Description,
            CityType = city.Result.SettlementTypeDescription,
            CityRef = warehouse.Result.CityRef,
            AreaRef = city.Result.Area,
            AreaName = area.Result.Description,
            WarehouseNumber = warehouse.Result.Ref,
            WarehouseDescription = warehouse.Result.Description
        });

        var customer = mapper.Map<CustomerInfoDto, CustomerServiceModel>(customerInfo);

        var customerModel = customerRepository.Create(customer);

        var order = new OrderServiceModel
        {
            CustomerId = customerModel.Id,
            DeliveryInfoId = deliveryInfo.Id
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

        return new OperationResult<(int orderId, IReadOnlyCollection<OrderDetailsServiceModel> orderDetails)>((orderModel.Id, createdOrderDetails));
    }
}