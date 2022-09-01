using Autofac;
using S148.Backend.NovaPoshta.Domain.Repositories;
using S148.Backend.NovaPoshta.Extensibility.Repositories;

namespace S148.Backend.NovaPoshta.Domain.AutofacModules;

public class NovaPoshtaDomainAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<NovaPoshtaInfoRepository>().As<INovaPoshtaInfoRepository>();
    }
}