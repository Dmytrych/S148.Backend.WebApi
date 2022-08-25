using S148.Backend.RestApi.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.Repositories;

namespace S148.Backend.Shopping.Service.Rest.Services;

public class ProductCrudService : CrudServiceBase<ProductServiceModel, ProductFilter>
{
    private readonly IProductCrudRepository crudRepository;
    
    public ProductCrudService(
        IProductCrudRepository crudRepository)
        : base(crudRepository)
    {
        this.crudRepository = crudRepository;
    }

    public override ProductServiceModel Get(int id)
    {
        return crudRepository.Get(id);
    }
}