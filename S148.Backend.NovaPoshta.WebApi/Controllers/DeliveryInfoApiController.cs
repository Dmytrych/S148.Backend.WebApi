using Microsoft.AspNetCore.Mvc;
using NovaPoshtaApi;
using S148.Backend.NovaPoshta.Extensibility.Services;
using S148.Backend.NovaPoshta.WebApi.Dto;

namespace S148.Backend.NovaPoshta.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DeliveryInfoApiController : ControllerBase
{
    private const string AreaString = "область";
    
    private readonly IDeliveryInfoService deliveryInfoService;

    public DeliveryInfoApiController(IDeliveryInfoService deliveryInfoService)
    {
        this.deliveryInfoService = deliveryInfoService;
    }
    
    [HttpGet]
    [Route("[action]")]
    public async Task<IReadOnlyCollection<CityClientDto>> GetCities([FromQuery]string nameFilter)
    {
        try
        {
            var results = new List<CityClientDto>();
            foreach (var city in await deliveryInfoService.GetCitiesAsync(nameFilter))
            {
                results.Add(await Convert(city));
            }

            return results;
        }
        catch
        {
            return null;
        }
    }
    
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetWarehouses(string cityId, string cityName, int limit = 20)
    {
        return Ok(await deliveryInfoService.GetWarehousesAsync(cityId, cityName, limit));
    }

    private async Task<CityClientDto> Convert(City city)
    {
        var area = await deliveryInfoService.GetArea(city.Area);

        var name = string.Concat(city.SettlementTypeDescription, " ", city.Description);

        if (area.IsValid)
        {
            name = string.Concat(name, ", ", area.Result.Description, " ", AreaString, " ");
        }

        return new CityClientDto
        {
            CityGuidRef = city.Ref,
            Description = name
        };
    }
}