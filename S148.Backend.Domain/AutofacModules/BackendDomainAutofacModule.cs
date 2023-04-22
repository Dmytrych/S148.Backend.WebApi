using Autofac;
using S148.Backend.Domain.Dto;
using S148.Backend.Domain.ProductSeeding;

namespace S148.Backend.Domain.AutofacModules;

public class BackendDomainAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<DatabaseContext>()
            .As<IDatabaseContext>().InstancePerLifetimeScope();

        builder
            .RegisterType<ExcelProductSeeder>()
            .As<IEntitySeeder<Product>>();
    }
}