using Autofac;

namespace S148.Backend.Domain.AutofacModules;

public class BackendDomainAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType(typeof(DatabaseContext))
            .As<IDatabaseContext>().InstancePerLifetimeScope();
    }
}