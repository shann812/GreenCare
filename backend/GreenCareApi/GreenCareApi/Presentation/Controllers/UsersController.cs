using GreenCareApi.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GreenCareApi.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("regist")]
        public async Task<IActionResult> RegistAsync(RegistrationUserDto dto)
        {
            return Ok();
        }
    }
}
