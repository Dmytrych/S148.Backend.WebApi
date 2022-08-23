using AutoMapper;
using Microsoft.EntityFrameworkCore;
using S148.Backend.Domain;
using S148.Backend.Domain.Dto;
using S148.Backend.RestApi.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Service.Rest.Repositories;

public class OrderDetailsCrudRepository : CrudRepositoryBase<OrderDetailsServiceModel, OrderDetails, OrderDetailsFilter>
{
    public OrderDetailsCrudRepository(IMapper mapper, DbSet<OrderDetails> entities, IDatabaseContext databaseContext) : base(mapper, entities, databaseContext)
    {
    }

    public override OrderDetailsServiceModel Update(OrderDetailsServiceModel model)
    {
        throw new NotImplementedException();
    }

    public override bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public override OrderDetailsServiceModel Get(int id)
    {
        throw new NotImplementedException();
    }

    public override IReadOnlyCollection<OrderDetailsServiceModel> GetAll(OrderDetailsFilter model)
    {
        throw new NotImplementedException();
    }
}