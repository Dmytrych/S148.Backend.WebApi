using AutoMapper;
using S148.Backend.Domain;
using S148.Backend.Domain.Dto;
using S148.Backend.RestApi.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Service.Rest.Repositories;

public class OrderCrudRepository : CrudRepositoryBase<OrderServiceModel, Order, OrderFilter>
{
    public OrderCrudRepository(IMapper mapper, IDatabaseContext databaseContext)
        : base(mapper, databaseContext.Orders, databaseContext)
    {
    }

    public override OrderServiceModel Update(OrderServiceModel model)
    {
        throw new NotImplementedException();
    }

    public override bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public override OrderServiceModel Get(int id)
    {
        throw new NotImplementedException();
    }

    public override IReadOnlyCollection<OrderServiceModel> GetAll(OrderFilter model)
    {
        throw new NotImplementedException();
    }
}