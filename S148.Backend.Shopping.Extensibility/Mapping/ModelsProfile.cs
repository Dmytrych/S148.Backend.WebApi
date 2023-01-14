using AutoMapper;
using S148.Backend.Domain.Dto;
using S148.Backend.Shopping.Extensibility.Models.Service;

namespace S148.Backend.Shopping.Extensibility.Mapping;

public class ModelsProfile : Profile
{
    public ModelsProfile()
    {
        CreateMap<CustomerServiceModel, Customer>().ReverseMap();
        CreateMap<OrderServiceModel, Order>().ReverseMap();
        CreateMap<OrderDetailsServiceModel, OrderDetails>().ReverseMap();
        CreateMap<ProductServiceModel, Product>().ReverseMap();
        CreateMap<DeliveryInfoServiceModel, DeliveryInfo>().ReverseMap();
        CreateMap<NovaPoshtaDeliveryInfoServiceModel, NovaPoshtaDeliveryInfo>().ReverseMap();
    }
}