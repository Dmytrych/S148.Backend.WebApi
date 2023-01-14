using S148.Backend.Extensibility;
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
    
    public OperationResult Validate(NovaPoshtaOrderData novaPoshtaOrderData)
    {
        if (!novaPoshtaOrderData.Products.Any() || novaPoshtaOrderData.CityGuidRef == null || novaPoshtaOrderData.WarehouseNumber <= 0)
        {
            throw new ArgumentException();
        }

        var customerValidationResult = customerInfoValidator.Validate(novaPoshtaOrderData.CustomerModel);

        if (!customerValidationResult.IsValid)
        {
            throw new ArgumentException();
        }

        var allProductIds = productRepository.GetAll();
        if (!novaPoshtaOrderData.Products.All(product => allProductIds.Contains(product.ProductId)))
        {
            throw new ArgumentException();
        }

        if (novaPoshtaOrderData.Products.DistinctBy(p => p.ProductId).Count() != novaPoshtaOrderData.Products.Count)
        {
            throw new ArgumentException();
        }

        return new OperationResult(true);
    }
}