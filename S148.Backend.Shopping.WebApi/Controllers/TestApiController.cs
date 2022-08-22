using Microsoft.AspNetCore.Mvc;
using S148.Backend.Domain;
using Swashbuckle.AspNetCore.Annotations;

namespace S148.Backend.Shopping.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestApiController : ControllerBase
    {
        private IDatabaseContext testClass;

        public TestApiController(IDatabaseContext testClass)
        {
            this.testClass = testClass;
        }

        [HttpPost]
        [SwaggerOperation("Test","Test test")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}