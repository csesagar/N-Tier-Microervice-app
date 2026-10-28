using AutoMapper;
using Mango.Services.CouponApi.Models;
using Mango.Services.CouponApi.Models.Dto;
using Microsoft.Extensions.Logging.Abstractions;

namespace Mango.Services.CouponApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();        // here both have same structure dto and normal one in model 
                config.CreateMap<Coupon, CouponDto>();

            }, NullLoggerFactory.Instance);
            return mappingConfig;
        }
    }
}
