using Mango.Web.Service.IService;
using Mango.Web.DTOs;
using static Mango.Web.Utils.StaticDetails;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO<CouponDTO>?> GetCouponByCodeAsync(string couponCode)
        {
            return await _baseService.SendAsync<CouponDTO>(new RequestDTO()
            {
                ApiType = ApiType.GET,
                Url = $"{CouponAPIBase}/api/Coupon/Code/{couponCode}"
            });
        }

        public async Task<ResponseDTO<List<CouponDTO>>> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync<List<CouponDTO>>(new RequestDTO()
            {
                ApiType = ApiType.GET,
                Url = $"{CouponAPIBase}/api/Coupon"
            });
        }

        public async Task<ResponseDTO<CouponDTO>?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync<CouponDTO>(new RequestDTO()
            {
                ApiType = ApiType.GET,
                Url = $"{CouponAPIBase}/api/Coupon/{id}"
            });
        }

        public async Task<ResponseDTO<bool>> CreateCouponAsync(CouponDTO dto)
        {
            return await _baseService.SendAsync<bool>(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Url = $"{CouponAPIBase}/api/Coupon",
                Data = dto
            });
        }

        public async Task<ResponseDTO<int>> UpdateCouponAsync(CouponDTO dto)
        {
            return await _baseService.SendAsync<int>(new RequestDTO()
            {
                ApiType = ApiType.PUT,
                Url = $"{CouponAPIBase}/api/Coupon/{dto.CouponId}",
                Data = dto
            });
        }

        public async Task<ResponseDTO<int>> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync<int>(new RequestDTO()
            {
                ApiType = ApiType.DELETE,
                Url = $"{CouponAPIBase}/api/Coupon/{id}",
            });
        }
    }
}
