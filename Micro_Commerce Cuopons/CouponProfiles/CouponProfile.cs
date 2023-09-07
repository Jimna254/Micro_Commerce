using AutoMapper;
using Micro_Commerce_Cuopons.Models;
using Micro_Commerce_Cuopons.Models.DTOs;

namespace Micro_Commerce_Cuopons.CouponProfiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<CouponRequestDTO, Coupon>().ReverseMap();
        }
    }
}
