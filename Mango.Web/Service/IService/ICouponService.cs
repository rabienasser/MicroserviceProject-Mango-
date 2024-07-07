using Mango.Web.DTOs;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO<CouponDTO>?> GetCouponByCodeAsync(string couponCode);
        Task<ResponseDTO<List<CouponDTO>>> GetAllCouponsAsync();
        Task<ResponseDTO<CouponDTO>?> GetCouponByIdAsync(int id);
        Task<ResponseDTO<bool>> CreateCouponAsync(CouponDTO dto);
        Task<ResponseDTO<int>> UpdateCouponAsync(CouponDTO dto);
        Task<ResponseDTO<int>> DeleteCouponAsync(int id);
    }
}
