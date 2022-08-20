using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace S148.Backend.RestApi.Extensibility;

public abstract class RestApiControllerBase<TRestModel, TServiceModel, TFilter> : ControllerBase
{
    [HttpPost]
    [Route("[action]")]
    [SwaggerOperation("Create models")]
    [SwaggerResponse(200, "Models created")]
    [SwaggerResponse(201, "Model created")]
    [SwaggerResponse(400, "Invalid data provided")]
    public IActionResult Create([FromBody] IEnumerable<TRestModel> model)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete]
    [Route("[action]")]
    [SwaggerOperation("Delete model")]
    [SwaggerResponse(200, "Model deleted")]
    [SwaggerResponse(400, "Invalid data provided")]
    public IActionResult Delete()
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [Route("[action]")]
    [SwaggerOperation("Update model")]
    [SwaggerResponse(200, "Models updated")]
    [SwaggerResponse(201, "Model updated")]
    [SwaggerResponse(400, "Invalid data provided")]
    public IActionResult Update()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    [Route("[action]")]
    [SwaggerOperation("Get model")]
    [SwaggerResponse(200, "Model found")]
    [SwaggerResponse(400, "Invalid data provided")]
    
    public IActionResult Get()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    [Route("[action]")]
    [SwaggerOperation("Create model")]
    [SwaggerResponse(200, "Models found")]
    [SwaggerResponse(400, "Invalid data provided")]
    public IActionResult GetAll()
    {
        throw new NotImplementedException();
    }

    protected TRestModel Convert(TServiceModel serviceModel)
    {
        
    }
    
    protected TServiceModel Convert(TRestModel restModel)
    {
        
    }
}