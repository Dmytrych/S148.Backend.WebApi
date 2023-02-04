using Microsoft.AspNetCore.Mvc;
using S148.Backend.Shopping.Extensibility.OrderPlacement;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderPlacementApiController : ControllerBase
{
    private const string NovaPoshtaDeliveryActionName = "novaPoshta";

    private readonly IOrderPlacementService<NovaPoshtaOrderData> novaPoshtaOrderPlacementService;

    public OrderPlacementApiController(IOrderPlacementService<NovaPoshtaOrderData> novaPoshtaOrderPlacementService)
    {
        this.novaPoshtaOrderPlacementService = novaPoshtaOrderPlacementService;
    }

    [HttpPost]
    [Route($"{NovaPoshtaDeliveryActionName}/[action]")]
    public IActionResult Create([FromBody]NovaPoshtaOrderData orderData)
    {
        try
        {
            var creationResult = novaPoshtaOrderPlacementService.Create(orderData);
            return Ok(creationResult);
        }
        catch
        {
            return BadRequest();
        }
    }
}