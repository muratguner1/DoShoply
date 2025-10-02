using DoShoply.Core.Common;
using DoShoply.Core.Dtos.UserDtos;
using DoShoply.Core.Interfaces.IRepositories;
using DoShoply.Domain.Entities;
using DoShoply.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoShoply.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepository(AppDbContext context, RoleManager<IdentityRole> roleManager, UserManager<User> userManager) : base(context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public Task<BaseResponseModel> Login(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseModel> Register(RegisterDto dto)
        {
            bool isAnyUser = await IsAnyItem(x => x.Email == dto.Email);

            if(isAnyUser)
            {
                return new BaseResponseModel
                {
                    Success = false,
                    Message = "This email is already in use!"
                };
            }

            var result = await _userManager.CreateAsync(new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                ConfirmPassword = dto.ConfirmPassword,
            }, dto.Password);

            if(result.Succeeded)
            {
                var isItTrue = await _roleManager.RoleExistsAsync("Admin");

                if(!isItTrue)
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("Supervisor"));
                    await _roleManager.CreateAsync(new IdentityRole("Customer"));
                    await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(dto.Email), "Admin");
                    await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(dto.Email), "Supervisor");
                    await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(dto.Email), "Customer");
                }
                else
                {
                    await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(dto.Email), "Customer");
                }

                return new BaseResponseModel
                {
                    Success = true,
                    Message = "User created successfully"
                };

            }
            else
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return new BaseResponseModel
                {
                    Success = false,
                    Message = errors
                };
            }    
        }
    }
}

