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
    public ProductsRestApiController(
        ICrudService<ProductServiceModel, ProductFilter> crudService,
        IMapper mapper)
        : base(crudService, mapper)
    {
    }
}