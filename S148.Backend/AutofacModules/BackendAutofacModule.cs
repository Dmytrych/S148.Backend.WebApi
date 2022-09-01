using Autofac;
using S148.Backend.Extensibility.NovaPoshta;
using S148.Backend.Extensibility.NovaPoshta.Models;
using S148.Backend.Extensibility.NovaPoshta.ParameterCreators;

namespace S148.Backend.AutofacModules
{
    public class BackendAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            BindParameterCreators(builder);

            builder.RegisterType<LimitableAddressClient>().As<ILimitableAddressClient>();
            builder.RegisterType<CustomNovaPoshtaClient>().As<ICustomNovaPoshtaClient>();
        }

        private void BindParameterCreators(ContainerBuilder builder)
        {
            builder.RegisterType<CityParameterCreator>().As<IParameterCreator<LimitedCityParameters, CityFilter>>();
            builder.RegisterType<WarehouseParameterCreator>().As<IParameterCreator<LimitedWarehouseParameters, WarehouseFilter>>();
        }
    }
}