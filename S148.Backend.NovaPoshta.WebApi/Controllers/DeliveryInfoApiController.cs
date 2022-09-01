using Microsoft.AspNetCore.Mvc;
using S148.Backend.NovaPoshta.Extensibility.Services;

namespace S148.Backend.NovaPoshta.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DeliveryInfoApiController : ControllerBase
{
    private readonly IDeliveryInfoService deliveryInfoService;
    
    public DeliveryInfoApiController(IDeliveryInfoService deliveryInfoService)
    {
        this.deliveryInfoService = deliveryInfoService;
    }
    
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetCities(string nameFilter)
    {
        return Ok(await deliveryInfoService.GetCitiesAsync(nameFilter));
    }
    
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetWarehouses(string cityId, string cityName, int limit = 20)
    {
        return Ok(await deliveryInfoService.GetWarehousesAsync(cityId, cityName, limit));
    }
}