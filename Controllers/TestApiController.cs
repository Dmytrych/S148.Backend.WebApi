using Microsoft.AspNetCore.Mvc;

namespace S148.Backend.Controllers
{
    public class TestApiController : ControllerBase
    {
        private ITestClass testClass;
        
        public TestApiController(ITestClass testClass)
        {
            this.testClass = testClass;
        }

        public IActionResult Test()
        {
            testClass.Test();
            return Ok();
        }
    }
}