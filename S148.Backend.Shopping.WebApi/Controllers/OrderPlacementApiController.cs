using Microsoft.AspNetCore.Mvc;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderPlacementApiController : ControllerBase
{
    private const string NovaPoshtaDeliveryActionName = "novaPoshta";

    [HttpPost]
    [Route("{NovaPoshtaDeliveryActionName}/[action]")]
    public IActionResult Create(
        CustomerInfoDto customerInfo,
        IReadOnlyCollection<ProductOrderingInfo> products,
        Guid cityGuidRef,
        string postIndex)
    {
        try
        {
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}