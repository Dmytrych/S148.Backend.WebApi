using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace S148.Backend.RestApi.Extensibility;

public abstract class RestApiControllerBase<TRestModel, TRestCreateModel, TServiceModel, TFilter> : ControllerBase
{
    private readonly ICrudService<TServiceModel, TFilter> crudService;
    private readonly IMapper mapper;
    
    protected RestApiControllerBase(
        ICrudService<TServiceModel, TFilter> crudService,
        IMapper mapper)
    {
        this.crudService = crudService;
        this.mapper = mapper;
    }

    [NonAction]
    [HttpPost]
    [Route("[action]")]
    [SwaggerOperation("Create models")]
    [SwaggerResponse(200, "Models created")]
    [SwaggerResponse(201, "Model created")]
    [SwaggerResponse(400, "Invalid data provided")]
    public IActionResult Create([FromBody] IEnumerable<TRestCreateModel> models)
    {
        var serviceModels = models.Select(Convert).ToList();
        var results = serviceModels.Select(crudService.Create);

        if (results.Any(result => result.IsValid))
        {
            return Ok(results);
        }

        return BadRequest(results);
    }
    
    [NonAction]
    [HttpDelete]
    [Route("[action]")]
    [SwaggerOperation("Delete model")]
    [SwaggerResponse(200, "Model deleted")]
    [SwaggerResponse(400, "Invalid data provided")]
    public IActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }

    [NonAction]
    [HttpPost]
    [Route("[action]")]
    [SwaggerOperation("Update model")]
    [SwaggerResponse(200, "Models updated")]
    [SwaggerResponse(201, "Model updated")]
    [SwaggerResponse(400, "Invalid data provided")]
    public IActionResult Update(TRestModel model)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("[action]")]
    [SwaggerOperation("Get model")]
    [SwaggerResponse(200, "Model found")]
    [SwaggerResponse(400, "Invalid data provided")]
    public IActionResult Get(int id)
    {
        var result = crudService.Get(id);
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    [HttpGet]
    [Route("[action]")]
    [SwaggerOperation("Get all models")]
    [SwaggerResponse(200, "Models found")]
    [SwaggerResponse(400, "Invalid data provided")]
    public IActionResult GetAll([FromQuery]TFilter filter)
    {
        var result = crudService.GetAll(filter);
        
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    protected virtual TRestModel Convert(TServiceModel serviceModel)
        => mapper.Map<TServiceModel, TRestModel>(serviceModel);

    protected virtual TServiceModel Convert(TRestModel restModel)
        => mapper.Map<TRestModel, TServiceModel>(restModel);
    
    protected virtual TServiceModel Convert(TRestCreateModel restModel)
        => mapper.Map<TRestCreateModel, TServiceModel>(restModel);
}