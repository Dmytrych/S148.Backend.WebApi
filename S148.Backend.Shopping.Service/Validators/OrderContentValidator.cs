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
    
    public OperationResult Validate(IReadOnlyCollection<ProductOrderingInfo> products)
    {
        if (products.IsNullOrEmpty())
        {
            throw new ArgumentException();
        }
        
        var allProductIds = productRepository.GetAll();
        if (!products.All(product => allProductIds.Contains(product.ProductId)))
        {
            throw new ArgumentException();
        }

        if (products.DistinctBy(p => p.ProductId).Count() != products.Count)
        {
            throw new ArgumentException();
        }

        return new OperationResult(true);
    }
}