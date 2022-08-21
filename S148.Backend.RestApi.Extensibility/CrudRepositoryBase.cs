using AutoMapper;
using Microsoft.EntityFrameworkCore;
using S148.Backend.Domain;

namespace S148.Backend.RestApi.Extensibility;

public abstract class CrudRepositoryBase<TServiceModel, TEntity, TFilter> : ICrudRepository<TServiceModel, TFilter>
    where TEntity : class
{
    private readonly IMapper mapper;
    private readonly DbSet<TEntity> entities;
    protected readonly IDatabaseContext databaseContext;
    
    public CrudRepositoryBase(IMapper mapper, DbSet<TEntity> entities, IDatabaseContext databaseContext)
    {
        this.mapper = mapper;
        this.entities = entities;
        this.databaseContext = databaseContext;
    }

    public virtual TServiceModel Create(TServiceModel model)
    {
        var entity = Convert(model);
        var createdEntity = entities.Add(entity);
        databaseContext.SaveChanges();
        return Convert(createdEntity.Entity);
    }

    public abstract TServiceModel Update(TServiceModel model);

    public abstract bool Delete(int id);

    public abstract TServiceModel Get(int id);

    public abstract IReadOnlyCollection<TServiceModel> GetAll(TFilter model);

    protected virtual TEntity Convert(TServiceModel serviceModel)
        => mapper.Map<TServiceModel, TEntity>(serviceModel);

    protected virtual TServiceModel Convert(TEntity entity)
        => mapper.Map<TEntity, TServiceModel>(entity);
}