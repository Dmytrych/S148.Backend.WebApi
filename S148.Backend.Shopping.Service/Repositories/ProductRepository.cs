using S148.Backend.Domain;

namespace S148.Backend.Shopping.Service.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IDatabaseContext databaseContext;

    public ProductRepository(IDatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }

    public IReadOnlyCollection<int> GetAll()
        => databaseContext.Products.Select(p => p.Id).ToList();

    public decimal? GetPrice(int id)
        => databaseContext.Products.FirstOrDefault(p => p.Id == id)?.UnitPrice;
}