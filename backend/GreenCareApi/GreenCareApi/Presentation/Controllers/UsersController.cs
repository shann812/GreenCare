using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenCareApi.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("regist")]
        public async Task<IActionResult> RegistAsync(RegistrationUserDto dto)
        {
            await _userService.RegistAsync(dto);
            return Ok();
        }
    }
}
