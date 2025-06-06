using AutoMapper;
using WebMarket.DTOs;
using WebMarket.Models;

namespace WebMarket.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<RegisterDto, User>();
            CreateMap<LoginDto, User>();
            CreateMap<Product, ProductDto>();
            CreateMap<Purchase, UserPurchasesDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl))
                .ForMember(dest => dest.OldPrice, opt => opt.MapFrom(src => src.Product.OldPrice));
            CreateMap<User, UserDto>();


        }
    }
}
