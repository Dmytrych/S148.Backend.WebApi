using S148.Backend.RestApi.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.OrderPlacement;

internal class OrderPlacementService : IOrderPlacementService
{
    private readonly ICrudRepository<CustomerServiceModel, CustomerFilter> customerRepository;
    private readonly ICrudRepository<OrderServiceModel, CustomerFilter> orderRepository;
    private readonly ICrudRepository<OrderDetailsServiceModel, CustomerFilter> orderDetailsRepository;

    public OrderPlacementService(
        ICrudRepository<CustomerServiceModel, CustomerFilter> customerRepository,
        ICrudRepository<OrderServiceModel, CustomerFilter> orderRepository,
        ICrudRepository<OrderDetailsServiceModel, CustomerFilter> orderDetailsRepository)
    {
        this.customerRepository = customerRepository;
        this.orderRepository = orderRepository;
        this.orderDetailsRepository = orderDetailsRepository;
    }

    public Guid Create(CustomerInfoDto customerInfo, IReadOnlyCollection<ProductOrderingInfo> products)
    {

    }
}