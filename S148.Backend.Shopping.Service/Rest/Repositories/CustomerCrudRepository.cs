using AutoMapper;
using S148.Backend.Domain;
using S148.Backend.Domain.Dto;
using S148.Backend.RestApi.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Service.Rest.Repositories;

public class CustomerCrudRepository : CrudRepositoryBase<CustomerServiceModel, Customer, CustomerFilter>
{
    public CustomerCrudRepository(IMapper mapper, IDatabaseContext databaseContext)
        : base(mapper, databaseContext.Customers, databaseContext)
    {
    }

    public override CustomerServiceModel Update(CustomerServiceModel model)
    {
        throw new NotImplementedException();
    }

    public override bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public override CustomerServiceModel Get(int id)
    {
        throw new NotImplementedException();
    }

    public override IReadOnlyCollection<CustomerServiceModel> GetAll(CustomerFilter filter)
    {
        var filteredModels = databaseContext.Customers.Where(customer => filter.Id.Any(idFilter => idFilter == customer.Id));
        return filteredModels.Select(x => Convert(x)).ToList();
    }
}