using DoShoply.Core.Common;
using DoShoply.Core.Dtos.UserDtos;

namespace DoShoply.Core.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<BaseResponseModel> Login(LoginDto dto);
        Task<BaseResponseModel> Register(RegisterDto dto);
    }
}
