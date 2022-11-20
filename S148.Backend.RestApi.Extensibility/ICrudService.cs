using S148.Backend.Extensibility;

namespace S148.Backend.RestApi.Extensibility;

public interface ICrudService<TServiceModel, in TFilter>
{
    OperationResult<TServiceModel> Create(TServiceModel model);

    OperationResult<TServiceModel> Update(TServiceModel model);

    OperationResult Delete(int id);

    TServiceModel Get(int id);

    IReadOnlyCollection<TServiceModel> GetAll(TFilter filter);
}