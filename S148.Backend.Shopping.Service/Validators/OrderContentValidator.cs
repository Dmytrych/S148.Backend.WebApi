using ErrorOr;
using S148.Backend.Extensibility;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;
using S148.Backend.Shopping.Service.Repositories;

namespace S148.Backend.Shopping.Service.Validators;

internal class OrderContentValidator : IOrderContentValidator
{
    private readonly IProductRepository productRepository;

    public OrderContentValidator(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    
    public ErrorOr<Success> Validate(IReadOnlyCollection<ProductOrderingInfo> products)
    {
        if (products.IsNullOrEmpty())
        {
            return Error.NotFound("No products given");
        }
        
        var allProductIds = productRepository.GetAll();
        if (!products.All(product => allProductIds.Contains(product.ProductId)))
        {
            return Error.NotFound("The cart contains non-existing products");
        }

        return products.DistinctBy(p => p.ProductId).Count() != products.Count
            ? Error.Validation("The cart contains duplicated products")
            : Result.Success;
    }
}