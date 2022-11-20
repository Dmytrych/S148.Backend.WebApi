namespace S148.Backend.RestApi.Extensibility.Repositories;

public interface ICrudRepository<TServiceModel, in TFilter>
{
    TServiceModel Create(TServiceModel model);

    TServiceModel Update(TServiceModel model);

    IReadOnlyCollection<TServiceModel> GetAll(TFilter filterModel);
}