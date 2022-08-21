using S148.Backend.RestApi.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Service.Rest.Services;

public class ProductCrudService : CrudServiceBase<ProductServiceModel, ProductFilter>
{
    public ProductCrudService(
        ICrudRepository<ProductServiceModel, ProductFilter> crudRepository)
        : base(crudRepository)
    {
    }
}