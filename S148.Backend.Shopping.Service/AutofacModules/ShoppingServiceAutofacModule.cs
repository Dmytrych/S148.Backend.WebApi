using Autofac;
using AutoMapper;
using S148.Backend.RestApi.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Service.MappingProfiles;
using S148.Backend.Shopping.Service.Rest.Repositories;
using S148.Backend.Shopping.Service.Rest.Services;

namespace S148.Backend.Shopping.Service.AutofacModules;

public class ShoppingServiceAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductMappingProfile>().As<Profile>();
        builder.RegisterType<ProductCrudService>().As<ICrudService<ProductServiceModel, ProductFilter>>();
        builder.RegisterType<ProductCrudRepository>().As<ICrudRepository<ProductServiceModel, ProductFilter>>();
    }
}