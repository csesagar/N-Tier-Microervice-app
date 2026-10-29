using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.Extensions.Logging.Abstractions;

namespace Mango.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();        // here both have same structure dto and normal one in model 
                config.CreateMap<Product, ProductDto>();

            }, NullLoggerFactory.Instance);
            return mappingConfig;
        }
    }
}
