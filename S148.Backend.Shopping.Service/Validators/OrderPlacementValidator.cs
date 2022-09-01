using S148.Backend.Extensibility;
using S148.Backend.Extensibility.StringUtils;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;
using S148.Backend.Shopping.Service.Repositories;

namespace S148.Backend.Shopping.Service.Validators;

public class OrderPlacementValidator : IOrderPlacementValidator
{
    private readonly ICustomerInfoValidator customerInfoValidator;
    private readonly IProductRepository productRepository;
    
    public OrderPlacementValidator(ICustomerInfoValidator customerInfoValidator, IProductRepository productRepository)
    {
        this.customerInfoValidator = customerInfoValidator;
        this.productRepository = productRepository;
    }
    
    public OperationResult Validate(CustomerInfoDto customerInfo, IReadOnlyCollection<ProductOrderingInfo> products, string cityId, int warehouseNumber)
    {
        if (!products.Any() || cityId.IsNullOrEmpty() || warehouseNumber <= 0)
        {
            throw new ArgumentException();
        }

        var customerValidationResult = customerInfoValidator.Validate(customerInfo);

        if (!customerValidationResult.IsValid)
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