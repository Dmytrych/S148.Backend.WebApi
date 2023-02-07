using Autofac;

namespace S148.Backend.Domain.AutofacModules;

public class BackendDomainAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<DatabaseContext>()
            .As<IDatabaseContext>().InstancePerLifetimeScope();
    }
}