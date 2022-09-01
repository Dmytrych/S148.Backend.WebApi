using AutoMapper;
using S148.Backend.Domain;
using S148.Backend.Domain.Dto;
using S148.Backend.RestApi.Extensibility.Repositories;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.Repositories;

namespace S148.Backend.Shopping.Service.Rest.Repositories;

public class DeliveryInfoCrudRepository : CrudRepositoryBase<DeliveryInfoServiceModel, DeliveryInfo, DeliveryInfoFilter>, IDeliveryInfoCrudRepository
{
    public DeliveryInfoCrudRepository(IMapper mapper, IDatabaseContext databaseContext)
        : base(mapper, databaseContext.DeliveryInfo, databaseContext)
    {
    }

    public override DeliveryInfoServiceModel Update(DeliveryInfoServiceModel model)
    {
        throw new NotImplementedException();
    }

    public override IReadOnlyCollection<DeliveryInfoServiceModel> GetAll(DeliveryInfoFilter model)
    {
        throw new NotImplementedException();
    }

    public DeliveryInfoServiceModel? Get(int identifier)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}