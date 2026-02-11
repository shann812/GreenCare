using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.DTOs.Responses;
using GreenCareApi.Application.Interfaces;
using GreenCareApi.Presentation.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GreenCareApi.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            return Ok(ApiResponse<LoginResponseDto>.Ok(result));
        }
    }
}
