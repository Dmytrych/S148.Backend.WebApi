using Autofac;
using S148.Backend.Domain.AutofacModules;
using S148.Backend.NovaPoshta.Domain.AutofacModules;
using S148.Backend.NovaPoshta.Service.AutofacModules;
using S148.Backend.Shopping.Service.AutofacModules;

namespace S148.Backend.AutofacModules;

public static class ModuleRegistry
{
    public static IReadOnlyCollection<Module> GetAutofacModules(IConfiguration configuration)
        => new List<Module>
        {
            new BackendAutofacModule(),
            new BackendDomainAutofacModule(),
            new ShoppingServiceAutofacModule(),
            new NovaPoshtaServiceAutofacModule(),
            new NovaPoshtaDomainAutofacModule()
        };
}