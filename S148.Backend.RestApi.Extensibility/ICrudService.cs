
using ErrorOr;

namespace S148.Backend.RestApi.Extensibility;

public interface ICrudService<TServiceModel, in TFilter> : ICrudService<TServiceModel, TFilter, int>
{
}

public interface ICrudService<TServiceModel, in TFilter, TIdentifier>
{
    ErrorOr<TServiceModel> Create(TServiceModel model);

    ErrorOr<TServiceModel> Update(TServiceModel model);

    Error Delete(TIdentifier id);

    TServiceModel Get(TIdentifier id);

    IReadOnlyCollection<TServiceModel> GetAll(TFilter filter);
}