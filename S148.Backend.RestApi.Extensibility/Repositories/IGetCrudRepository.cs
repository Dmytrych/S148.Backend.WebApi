namespace S148.Backend.RestApi.Extensibility.Repositories;

public interface IGetCrudRepository<TServiceModel, TIdentifierContainer>
{
    TServiceModel? Get(TIdentifierContainer identifier);
}