using Autofac;
using S148.Backend.Extensibility;
using S148.Backend.Extensibility.NovaPoshta;
using S148.Backend.Extensibility.NovaPoshta.Models;
using S148.Backend.Extensibility.NovaPoshta.OnlineSettlementSearch;
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
            builder.RegisterType<QuickCitySearchClient>().As<IQuickCitySearchClient>();

            builder.RegisterType<OperationResultFactory>().As<IOperationResultFactory>();
        }

        private void BindParameterCreators(ContainerBuilder builder)
        {
            builder.RegisterType<CityParameterCreator>().As<IParameterCreator<LimitedCityParameters, CityFilter>>();
            builder.RegisterType<WarehouseParameterCreator>().As<IParameterCreator<LimitedWarehouseParameters, WarehouseFilter>>();
            builder.RegisterType<QuickCityParameterCreator>().As<IParameterCreator<LimitedQuickCityParameters, QuickCityFilter>>();
        }
    }
}