using Autofac;
using S148.Backend.NovaPoshta.Extensibility.Services;
using S148.Backend.NovaPoshta.Service.Services;

namespace S148.Backend.NovaPoshta.Service.AutofacModules;

public class NovaPoshtaServiceAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DeliveryInfoService>().As<IDeliveryInfoService>();
    }
}