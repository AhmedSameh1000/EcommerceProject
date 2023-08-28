using Api.DTOs;
using AutoMapper;
using Core.Models;

namespace Api.AutoMapperProfile
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dest => dest.productType, opt => { opt.MapFrom(src => src.productType.Name); })
                .ForMember(dest => dest.ProductBrand, opt => { opt.MapFrom(src => src.ProductBrand.Name); });
        }
    }
}
