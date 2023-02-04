using Autofac;
using S148.Backend.Domain.Seeders;

namespace S148.Backend.Domain.AutofacModules;

public class BackendDomainAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<DatabaseContext>()
            .As<IDatabaseContext>().InstancePerLifetimeScope();
        builder
            .RegisterType<EmbeddedImageSeeder>()
            .As<IEmbeddedImageSeeder>();
    }
}