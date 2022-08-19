using System.Reflection;
using Autofac;
using Microsoft.Extensions.DependencyModel;

namespace S148.Backend.Utils;

public static class AutofacUtils
{
    public static void RegisterAllModules(this ContainerBuilder builder)
    {
        var execAssembly = Assembly.GetExecutingAssembly();
        var dependencyContext = DependencyContext.Load(execAssembly);
        var assemblyNames = dependencyContext.GetDefaultAssemblyNames();
        assemblyNames.First(x => x.)

        foreach (var assemblyName in assemblyNames)
        {
            builder.RegisterAssemblyModules(Assembly.Load(assemblyName));
        }
    }
}