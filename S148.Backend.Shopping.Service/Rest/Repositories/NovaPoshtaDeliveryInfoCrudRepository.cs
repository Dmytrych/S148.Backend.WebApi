// using AutoMapper;
// using Microsoft.EntityFrameworkCore;
// using S148.Backend.Domain;
// using S148.Backend.Domain.Dto;
// using S148.Backend.RestApi.Extensibility.Repositories;
// using S148.Backend.Shopping.Extensibility.Models.Filters;
// using S148.Backend.Shopping.Extensibility.Models.Service;
// using S148.Backend.Shopping.Extensibility.Repositories;
//
// namespace S148.Backend.Shopping.Service.Rest.Repositories;
//
// public class NovaPoshtaDeliveryInfoCrudRepository
//     : CrudRepositoryBase<NovaPoshtaDeliveryInfoServiceModel, NovaPoshtaDeliveryInfo, NovaPoshtaDeliveryInfoFilter>, INovaPoshtaDeliveryInfoCrudRepository
// {
//     public NovaPoshtaDeliveryInfoCrudRepository(
//         IMapper mapper,
//         IDatabaseContext databaseContext)
//         : base(mapper, databaseContext.NovaPoshtaDeliveryInfo, databaseContext)
//     {
//     }
//
//     public override NovaPoshtaDeliveryInfoServiceModel Update(NovaPoshtaDeliveryInfoServiceModel model)
//     {
//         throw new NotImplementedException();
//     }
//
//     public override IReadOnlyCollection<NovaPoshtaDeliveryInfoServiceModel> GetAll(NovaPoshtaDeliveryInfoFilter filterModel)
//     {
//         throw new NotImplementedException();
//     }
//
//     public NovaPoshtaDeliveryInfoServiceModel? Get(int identifier)
//     {
//         throw new NotImplementedException();
//     }
//
//     public bool Delete(int id)
//     {
//         throw new NotImplementedException();
//     }
// }