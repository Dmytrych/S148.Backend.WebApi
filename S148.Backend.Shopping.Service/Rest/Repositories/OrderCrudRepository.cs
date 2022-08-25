using AutoMapper;
using S148.Backend.Domain;
using S148.Backend.Domain.Dto;
using S148.Backend.RestApi.Extensibility.Repositories;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.Repositories;

namespace S148.Backend.Shopping.Service.Rest.Repositories;

public class OrderCrudRepository : CrudRepositoryBase<OrderServiceModel, Order, OrderFilter>, IOrderCrudRepository
{
    public OrderCrudRepository(IMapper mapper, IDatabaseContext databaseContext)
        : base(mapper, databaseContext.Orders, databaseContext)
    {
    }

    public override OrderServiceModel Update(OrderServiceModel model)
    {
        throw new NotImplementedException();
    }

    public override IReadOnlyCollection<OrderServiceModel> GetAll(OrderFilter model)
    {
        IQueryable<Order> orders = databaseContext.Orders;
        
        if (model.Id.Any())
        {
            orders = orders.Where(c => model.Id.Any(id => id == c.Id));
        }

        return orders.Select(c => Convert(c)).ToList();
    }

    public OrderServiceModel? Get(int identifier)
    {
        var entity = databaseContext.Orders.FirstOrDefault(o => o.Id == identifier);
        return entity != null ? Convert(entity) : null;
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}