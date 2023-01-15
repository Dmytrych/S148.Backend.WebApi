using S148.Backend.Extensibility;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;
using S148.Backend.Shopping.Service.Repositories;

namespace S148.Backend.Shopping.Service.Validators;

internal class OrderContentValidator : IOrderContentValidator
{
    private readonly IProductRepository productRepository;

    private readonly IOperationResultFactory operationResultFactory;
    
    public OrderContentValidator(
        IOperationResultFactory operationResultFactory,
        IProductRepository productRepository)
    {
        this.productRepository = productRepository;
        this.operationResultFactory = operationResultFactory;
    }
    
    public OperationResult Validate(IReadOnlyCollection<ProductOrderingInfo> products)
    {
        if (products.IsNullOrEmpty())
        {
            return operationResultFactory.FromStatusCode(ShoppingProcessResultCodeNames.NoProductsSelected);
        }
        
        var allProductIds = productRepository.GetAll();
        if (!products.All(product => allProductIds.Contains(product.ProductId)))
        {
            return operationResultFactory.FromStatusCode(ShoppingProcessResultCodeNames.ContainsInvalidProducts);
        }

        return products.DistinctBy(p => p.ProductId).Count() != products.Count
            ? operationResultFactory.FromStatusCode(ShoppingProcessResultCodeNames.ContainsDuplicatedProducts)
            : new OperationResult(true);
    }
}