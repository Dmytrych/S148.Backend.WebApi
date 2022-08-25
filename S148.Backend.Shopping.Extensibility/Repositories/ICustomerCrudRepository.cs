using S148.Backend.RestApi.Extensibility.Repositories;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Extensibility.Repositories;

public interface ICustomerCrudRepository
    : ICrudRepository<CustomerServiceModel, CustomerFilter>,
        IGetCrudRepository<CustomerServiceModel, int>,
        IDeleteCrudRepository<CustomerServiceModel, int>
{
}