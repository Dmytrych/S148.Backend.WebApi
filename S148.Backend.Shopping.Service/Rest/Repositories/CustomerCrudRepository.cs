using AutoMapper;
using S148.Backend.Domain;
using S148.Backend.Domain.Dto;
using S148.Backend.RestApi.Extensibility.Repositories;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.Repositories;

namespace S148.Backend.Shopping.Service.Rest.Repositories;

public class CustomerCrudRepository : CrudRepositoryBase<CustomerServiceModel, Customer, CustomerFilter>, ICustomerCrudRepository
{
    public CustomerCrudRepository(IMapper mapper, IDatabaseContext databaseContext)
        : base(mapper, databaseContext.Customers, databaseContext)
    {
    }

    public override CustomerServiceModel Update(CustomerServiceModel model)
    {
        throw new NotImplementedException();
    }

    public override IReadOnlyCollection<CustomerServiceModel> GetAll(CustomerFilter filter)
    {
        var filteredModels = databaseContext.Customers.Where(customer => filter.Id.Any(idFilter => idFilter == customer.Id));
        return filteredModels.Select(x => Convert(x)).ToList();
    }

    public CustomerServiceModel? Get(int identifier)
    {
        var entity = databaseContext.Customers.FirstOrDefault(c => c.Id == identifier);

        return entity != null ? Convert(entity) : null;
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}