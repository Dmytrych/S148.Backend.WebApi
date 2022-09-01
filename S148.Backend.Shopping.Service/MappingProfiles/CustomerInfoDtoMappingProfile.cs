using AutoMapper;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.MappingProfiles;

public class CustomerInfoDtoMappingProfile : Profile
{
    public CustomerInfoDtoMappingProfile()
    {
        CreateMap<CustomerInfoDto, CustomerServiceModel>()
            .ForMember(
                m => m.Id,
                opt => opt.Ignore());
    }
}