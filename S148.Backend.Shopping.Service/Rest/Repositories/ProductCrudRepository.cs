using AutoMapper;
using S148.Backend.Domain;
using S148.Backend.Domain.Dto;
using S148.Backend.RestApi.Extensibility.Repositories;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.Repositories;

namespace S148.Backend.Shopping.Service.Rest.Repositories;

public class ProductCrudRepository : CrudRepositoryBase<ProductServiceModel, Product, ProductFilter>, IProductCrudRepository
{
    public ProductCrudRepository(
        IMapper mapper,
        IDatabaseContext databaseContext)
        : base(mapper, databaseContext.Products, databaseContext)
    {
    }

    public override ProductServiceModel Update(ProductServiceModel model)
    {
        throw new NotImplementedException();
    }

    public override IReadOnlyCollection<ProductServiceModel> GetAll(ProductFilter filterModel)
    {
        IQueryable<Product> products = databaseContext.Products;

        if (filterModel is { IdFilter: { } })
        {
            products = products.Where(details => filterModel.IdFilter.Filter.Any(filter => filter == details.Id));
        }

        return products.ToList().Select(p => Convert(p)).ToList();
    }

    public ProductServiceModel? Get(int identifier)
    {
        var foundEntity = databaseContext.Products.FirstOrDefault(p => p.Id == identifier);
        return foundEntity != null ? Convert(foundEntity) : null;
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}