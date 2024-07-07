using Mango.Web.DTOs;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO<T>?> SendAsync<T>(RequestDTO requestDto);
    }
}
