using Autofac;

namespace S148.Backend.Domain;

public class BackendDomainAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .Register(c => new DatabaseContext())
            .As<IDatabaseContext>().InstancePerRequest();
    }
}