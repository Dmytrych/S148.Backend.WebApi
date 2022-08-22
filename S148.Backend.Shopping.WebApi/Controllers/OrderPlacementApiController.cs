using Microsoft.AspNetCore.Mvc;
using S148.Backend.Shopping.WebApi.Controllers.Dto;

namespace S148.Backend.Shopping.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderPlacementApiController : ControllerBase
{
    public IActionResult Create(OrderPlacementRequestModel requestModel)
    {

    }
}