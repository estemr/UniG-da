using AutoMapper;
using TTS.Entity.DTOs.Market.Products;
using TTS.Entity.Entities.Market;

namespace TTS.Service.AutoMapper.Market.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, ProductDto>().ReverseMap();
            CreateMap<ProductAddDto, Product>().ReverseMap();
        }
    }
}
