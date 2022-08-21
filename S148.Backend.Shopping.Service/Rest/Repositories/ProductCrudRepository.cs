using AutoMapper;
using S148.Backend.Domain;
using S148.Backend.Domain.Dto;
using S148.Backend.RestApi.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Service.Rest.Repositories;

public class ProductCrudRepository : CrudRepositoryBase<ProductServiceModel, Product, ProductFilter>
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

    public override bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public override ProductServiceModel Get(int id)
    {
        var foundEntity = databaseContext.Products.FirstOrDefault(p => p.Id == id);
        return (foundEntity != null ? Convert(foundEntity) : null)!;
    }

    public override IReadOnlyCollection<ProductServiceModel> GetAll(ProductFilter model)
    {
        throw new NotImplementedException();
    }
}