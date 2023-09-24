using Api.DTOs;
using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Api.AutoMapperProfile
{
    public class AutoMapperProfiles:Profile
    {
  


        public AutoMapperProfiles()
        {
           
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dest => dest.productType, opt => { opt.MapFrom(src => src.productType.Name); })
                .ForMember(dest => dest.ProductBrand, opt => { opt.MapFrom(src => src.ProductBrand.Name); });

            CreateMap<Product, ProductImages>();

            CreateMap<User, UserDto>();
            CreateMap<cartItem,cartItemDTO>().ReverseMap();
            CreateMap<cartItem, CartItemToAdd>().ReverseMap();
            CreateMap<PaymentPackage, UserDataWithPackageData>().
                ForMember(dest => dest.OrderStatus, opt => { opt.MapFrom(src => src.Pending); });

        }
    }
}
