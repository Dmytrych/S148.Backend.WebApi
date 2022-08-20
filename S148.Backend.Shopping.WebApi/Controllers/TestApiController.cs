using Microsoft.AspNetCore.Mvc;
using S148.Backend.Domain;
using S148.Backend.Domain.Dto;
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
            testClass.Products.Add(new Product
            {
                Name = "Test",
                Price = "2323"
            });
            testClass.SaveChanges();
            return Ok();
        }
    }
}