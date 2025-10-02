using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoShoply.Core.Common;
using DoShoply.Core.Dtos.UserDtos;
using DoShoply.Core.Interfaces.IRepositories;
using DoShoply.Core.Interfaces.IServices;

namespace DoShoply.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseResponseModel> Register(RegisterDto dto)
        {
            var result = await _userRepository.Register(dto);
            return result;
        }
    }
}
