using S148.Backend.RestApi.Extensibility.Repositories;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Extensibility.Repositories;

public interface IOrderCrudRepository 
    : ICrudRepository<OrderServiceModel, OrderFilter>,
        IGetCrudRepository<OrderServiceModel, int>,
        IDeleteCrudRepository<OrderServiceModel, int>
{
}