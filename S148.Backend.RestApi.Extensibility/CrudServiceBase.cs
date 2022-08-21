using S148.Backend.Extensibility;

namespace S148.Backend.RestApi.Extensibility;

public abstract class CrudServiceBase<TServiceModel, TFilter> : ICrudService<TServiceModel, TFilter>
{
    private readonly ICrudRepository<TServiceModel, TFilter> crudRepository;
    
    public CrudServiceBase(ICrudRepository<TServiceModel, TFilter> crudRepository)
    {
        this.crudRepository = crudRepository;
    }

    public OperationResult<TServiceModel> Create(TServiceModel model)
    {
        throw new NotImplementedException();
    }
    
    public OperationResult<TServiceModel> Update(TServiceModel model)
    {
        throw new NotImplementedException();
    }
    
    public OperationResult Delete(int id)
    {
        throw new NotImplementedException();
    }

    public TServiceModel Get(int id)
        => crudRepository.Get(id);
    
    public IReadOnlyCollection<TServiceModel> GetAll(TFilter model)
    {
        throw new NotImplementedException();
    }
}