using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoShoply.Core.Common;
using DoShoply.Core.Dtos.UserDtos;

namespace DoShoply.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<BaseResponseModel> Register(RegisterDto dto);

    }
}
