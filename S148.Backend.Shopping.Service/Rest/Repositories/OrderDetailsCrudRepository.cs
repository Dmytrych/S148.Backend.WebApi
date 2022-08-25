using AutoMapper;
using Microsoft.EntityFrameworkCore;
using S148.Backend.Domain;
using S148.Backend.Domain.Dto;
using S148.Backend.RestApi.Extensibility.Repositories;
using S148.Backend.Shopping.Extensibility.Models;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.Repositories;

namespace S148.Backend.Shopping.Service.Rest.Repositories;

public class OrderDetailsCrudRepository : CrudRepositoryBase<OrderDetailsServiceModel, OrderDetails, OrderDetailsFilter>, IOrderDetailsCrudRepository
{
    public OrderDetailsCrudRepository(IMapper mapper, DbSet<OrderDetails> entities, IDatabaseContext databaseContext) : base(mapper, entities, databaseContext)
    {
    }

    public override OrderDetailsServiceModel Update(OrderDetailsServiceModel model)
    {
        throw new NotImplementedException();
    }

    public override IReadOnlyCollection<OrderDetailsServiceModel> GetAll(OrderDetailsFilter model)
    {
        IQueryable<OrderDetails> orderDetails = databaseContext.OrderDetails;
        
        if (model.OrderFilter != null)
        {
            orderDetails = orderDetails.Where(details => model.OrderFilter.Filter.Any(filter => filter == details.OrderId));
        }

        if (model.ProductFilter != null)
        {
            orderDetails = orderDetails.Where(details =>
                model.ProductFilter.Filter.Any(filter => filter == details.ProductId));
        }

        return orderDetails.Select(od => Convert(od)).ToList();
    }

    public OrderDetailsServiceModel Get(OrderDetailsIdentifierContainer identifier)
    {
        var entity = databaseContext.OrderDetails.FirstOrDefault(od =>
            od.OrderId == identifier.OrderId && od.ProductId == identifier.ProductId);

        return entity != null ? Convert(entity) : null;
    }

    public bool Delete(OrderDetailsIdentifierContainer id)
    {
        throw new NotImplementedException();
    }
}