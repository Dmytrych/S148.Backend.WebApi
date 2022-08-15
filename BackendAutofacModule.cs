using Autofac;
using S148.Backend.Controllers;

namespace S148.Backend
{
    public class BackendAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new TestClass()).As<ITestClass>();
        }
    }
}