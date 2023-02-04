using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using S148.Backend.Domain;
using S148.Backend.Domain.Dto;
using S148.Backend.RestApi.Extensibility;
using S148.Backend.Shopping.Extensibility.Models.Filters;
using S148.Backend.Shopping.Extensibility.Models.Rest;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.RestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsRestApiController : RestApiControllerBase<ProductRestModel, ProductRestCreateModel, ProductServiceModel, ProductFilter>
{
    private readonly IDatabaseContext databaseContext;
    
    public ProductsRestApiController(
        ICrudService<ProductServiceModel, ProductFilter> crudService,
        IDatabaseContext databaseContext,
        IMapper mapper)
        : base(crudService, mapper)
    {
        this.databaseContext = databaseContext;
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public IActionResult GetImage([FromRoute]int id)
    {
        var foundImage = databaseContext.Images.FirstOrDefault(image => image.Id == id);
        return foundImage != null
            ? File(foundImage.Content, GetContentTypeByExtension(foundImage.Extension))
            : NotFound();
    }

    private string GetContentTypeByExtension(string extension)
        => $"image/{extension.TrimStart('.')}";
}