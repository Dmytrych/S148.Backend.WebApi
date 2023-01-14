using Microsoft.AspNetCore.Mvc;
using S148.Backend.Extensibility.NovaPoshta.Models;
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
            return new List<CityClientDto>();
        }
    }
    
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetWarehouseByNumber(
        [FromQuery]Guid cityGuidRef,
        [FromQuery]int warehouseNumber)
    {
        var warehouse = await deliveryInfoService.GetWarehouseByNumberAsync(cityGuidRef, warehouseNumber);

        return warehouse.IsValid
            ? Ok(Convert(warehouse.Result))
            : NotFound();
    }

    private async Task<CityClientDto> Convert(City city)
    {
        var area = await deliveryInfoService.GetArea(city.Area);

        var fullName = string.Concat(city.SettlementTypeDescription, " ", city.Description);

        if (area.IsValid)
        {
            fullName = string.Concat(fullName, ", ", area.Result.Description, " ", AreaString, " ");
        }

        return new CityClientDto
        {
            CityGuidRef = city.Ref,
            Description = fullName,
            Name = city.Description
        };
    }
    
    private WarehouseClientDto Convert(Warehouse warehouse)
        => new()
        {
            Name = warehouse.Description,
            WarehouseGuidRef = warehouse.Ref
        };
}