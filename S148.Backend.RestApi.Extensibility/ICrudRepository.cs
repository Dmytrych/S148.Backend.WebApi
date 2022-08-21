namespace S148.Backend.RestApi.Extensibility;

public interface ICrudRepository<TServiceModel, in TFilter>
{
    TServiceModel Create(TServiceModel model);

    TServiceModel Update(TServiceModel model);

    bool Delete(int id);

    TServiceModel Get(int id);

    IReadOnlyCollection<TServiceModel> GetAll(TFilter model);
}