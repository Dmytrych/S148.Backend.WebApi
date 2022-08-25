using Microsoft.AspNetCore.Mvc;
using S148.Backend.Shopping.Extensibility.OrderPlacement;
using S148.Backend.Shopping.WebApi.Controllers.Dto;

namespace S148.Backend.Shopping.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderPlacementApiController : ControllerBase
{
    private readonly IOrderPlacementService orderPlacementService;

    public OrderPlacementApiController(IOrderPlacementService orderPlacementService)
    {
        this.orderPlacementService = orderPlacementService;
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult Create(OrderPlacementRequestModel requestModel)
    {
        try
        {
            var result = orderPlacementService.Create(requestModel.CustomerInfo, requestModel.Products);
            return Ok(result);
        }
        catch
        {
            return BadRequest();
        }
    }
}