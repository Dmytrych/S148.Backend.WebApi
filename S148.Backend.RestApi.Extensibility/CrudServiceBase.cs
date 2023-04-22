using ErrorOr;
using S148.Backend.RestApi.Extensibility.Repositories;

namespace S148.Backend.RestApi.Extensibility;

public abstract class CrudServiceBase<TServiceModel, TFilter> : CrudServiceBase<TServiceModel, TFilter, int>, ICrudService<TServiceModel, TFilter>
{
    protected CrudServiceBase(ICrudRepository<TServiceModel, TFilter> crudRepository)
        : base(crudRepository)
    {
    }
}

public abstract class CrudServiceBase<TServiceModel, TFilter, TIdentifier> : ICrudService<TServiceModel, TFilter, TIdentifier>
{
    private readonly ICrudRepository<TServiceModel, TFilter> crudRepository;
    
    protected CrudServiceBase(ICrudRepository<TServiceModel, TFilter> crudRepository)
    {
        this.crudRepository = crudRepository;
    }

    public ErrorOr<TServiceModel> Create(TServiceModel model)
    {
        throw new NotImplementedException();
    }
    
    public ErrorOr<TServiceModel> Update(TServiceModel model)
    {
        throw new NotImplementedException();
    }
    
    public Error Delete(TIdentifier id)
    {
        throw new NotImplementedException();
    }

    public abstract TServiceModel Get(TIdentifier id);

    public virtual IReadOnlyCollection<TServiceModel> GetAll(TFilter filter)
        => crudRepository.GetAll(filter);
}