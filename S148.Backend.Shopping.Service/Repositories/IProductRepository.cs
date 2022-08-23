namespace S148.Backend.Shopping.Service.Repositories;

public interface IProductRepository
{
    IReadOnlyCollection<int> GetAll();

    decimal? GetPrice(int id);
}