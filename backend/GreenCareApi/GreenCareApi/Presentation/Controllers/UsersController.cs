using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.Interfaces;
using GreenCareApi.Application.Services;
using GreenCareApi.Presentation.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GreenCareApi.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegistAsync(RegistrationUserDto dto)
        {
            await _userService.RegistAsync(dto);
            return Ok(ApiResponse.Ok());
        }
    }
}
