using AutoMapper;
using S148.Backend.Domain.Dto;
using S148.Backend.Shopping.Extensibility.Models.Rest;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Service.MappingProfiles;

public class ProductMappingProfile: Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductRestModel, ProductServiceModel>();
        CreateMap<ProductServiceModel, ProductRestModel>();
        CreateMap<ProductServiceModel, Product>();
        CreateMap<Product, ProductServiceModel>();
    }
}