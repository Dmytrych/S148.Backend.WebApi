using Microsoft.AspNetCore.Mvc;
using S148.Backend.RestApi.Extensibility;

namespace S148.Backend.Shopping.RestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsRestApiController : RestApiControllerBase<int, int, int>
{
}