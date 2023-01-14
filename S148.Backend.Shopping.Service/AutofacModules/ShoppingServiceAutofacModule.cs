using Autofac;
using AutoMapper;
using S148.Backend.RestApi.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;
using S148.Backend.Shopping.Extensibility.Repositories;
using S148.Backend.Shopping.Service.MappingProfiles;
using S148.Backend.Shopping.Service.OrderPlacement;
using S148.Backend.Shopping.Service.Repositories;
using S148.Backend.Shopping.Service.Rest.Repositories;
using S148.Backend.Shopping.Service.Rest.Services;
using S148.Backend.Shopping.Service.Validators;

namespace S148.Backend.Shopping.Service.AutofacModules;

public class ShoppingServiceAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductMappingProfile>().As<Profile>();
        builder.RegisterType<ProductCrudService>().As<ICrudService<ProductServiceModel, ProductFilter>>();

        BindRepositories(builder);
        BindValidators(builder);
        BindCounters(builder);
        BindServices(builder);
        BindFactories(builder);
    }

    private void BindFactories(ContainerBuilder builder)
    {
        builder.RegisterType<NovaPoshtaDeliveryInfoFactory>().As<INovaPoshtaDeliveryInfoFactory>();
    }

    private void BindServices(ContainerBuilder builder)
    {
        builder.RegisterType<NovaPoshtaOrderPlacementService>().As<IOrderPlacementService<NovaPoshtaOrderData>>();
    }

    private void BindCounters(ContainerBuilder builder)
    {
        builder.RegisterType<OrderPriceCounter>().As<IOrderPriceCounter>();
    }

    private void BindRepositories(ContainerBuilder builder)
    {
        builder.RegisterType<ProductCrudRepository>().As<IProductCrudRepository>();
        builder.RegisterType<OrderCrudRepository>().As<IOrderCrudRepository>();
        builder.RegisterType<CustomerCrudRepository>().As<ICustomerCrudRepository>();
        builder.RegisterType<OrderDetailsCrudRepository>().As<IOrderDetailsCrudRepository>();
        builder.RegisterType<DeliveryInfoCrudRepository>().As<IDeliveryInfoCrudRepository>();
        builder.RegisterType<NovaPoshtaDeliveryInfoCrudRepository>().As<INovaPoshtaDeliveryInfoCrudRepository>();

        builder.RegisterType<ProductRepository>().As<IProductRepository>();
    }

    private void BindValidators(ContainerBuilder builder)
    {
        builder.RegisterType<EmailValidator>().As<IEmailValidator>();
        builder.RegisterType<PhoneValidator>().As<IPhoneValidator>();
        builder.RegisterType<CustomerInfoValidator>().As<ICustomerInfoValidator>();
        builder.RegisterType<OrderPlacementValidator>().As<IOrderPlacementValidator>();
        builder.RegisterType<OrderContentValidator>().As<IOrderContentValidator>();
    }
}