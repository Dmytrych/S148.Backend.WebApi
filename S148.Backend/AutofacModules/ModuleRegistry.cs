using Autofac;
using S148.Backend.Domain.AutofacModules;

namespace S148.Backend.AutofacModules;

public static class ModuleRegistry
{
    public static IReadOnlyCollection<Module> GetAutofacModules()
        => new List<Module>
        {
            new BackendAutofacModule(),
            new BackendDomainAutofacModule()
        };
}