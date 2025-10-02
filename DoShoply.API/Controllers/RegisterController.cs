using DoShoply.Core.Dtos.UserDtos;
using DoShoply.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoShoply.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]RegisterDto dto)
        {
            var response = await _userService.Register(dto);
            if(response != null) 
                return Ok(response);
            return BadRequest();
        }
    }
}
