namespace S148.Backend.RestApi.Extensibility.Repositories;

public interface IDeleteCrudRepository<TServiceModel, TIdentifierContainer>
{
    bool Delete(TIdentifierContainer id);
}