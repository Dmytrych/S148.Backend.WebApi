using Autofac;
using S148.Backend.Shopping.WebApi.Controllers;

namespace S148.Backend.Shopping.WebApi.AutofacModules;

public class ShoppingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(c => new TestClass()).As<ITestClass>();
    }
}