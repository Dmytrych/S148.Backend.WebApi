namespace S148.Backend.Shopping.Service.Repositories;

public interface IProductRepository
{
    IReadOnlyCollection<int> GetAll();

    float? GetPrice(int id);
}