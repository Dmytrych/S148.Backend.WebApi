using S148.Backend.RestApi.Extensibility.Repositories;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Extensibility.Repositories;

public interface IDeliveryInfoCrudRepository: ICrudRepository<DeliveryInfoServiceModel, DeliveryInfoFilter>,
    IGetCrudRepository<DeliveryInfoServiceModel, int>,
    IDeleteCrudRepository<DeliveryInfoServiceModel, int>
{
    
}