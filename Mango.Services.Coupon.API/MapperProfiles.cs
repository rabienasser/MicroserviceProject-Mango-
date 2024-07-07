using AutoMapper;
using Mango.Services.CouponAPI.DTOs;
using Mango.Services.CouponAPI.Models;

namespace Mango.Services.CouponAPI
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Coupon, CouponDTO>().ReverseMap();
        }
    }
}
