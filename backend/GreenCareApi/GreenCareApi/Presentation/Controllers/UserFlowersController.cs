using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.DTOs.Responses;
using GreenCareApi.Application.Interfaces;
using GreenCareApi.Presentation.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenCareApi.Presentation.Controllers
{
    [Route("api/user-flowers")]
    public class UserFlowersController : Controller
    {
        private readonly IUserFlowersService _userFlowerService;
        public UserFlowersController(IUserFlowersService userFlowerService)
        {
            _userFlowerService = userFlowerService;
        }

        [Authorize]
        [HttpPost("create")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateFlowerAsync([FromForm] CreateUserFlowerDto dto)
        {
            await _userFlowerService.CreateAsync(dto);
            return Ok(ApiResponse.Ok());
        }

        [Authorize]
        [HttpGet("my")]
        public async Task<IActionResult> GetMyFlowers([FromQuery] int page = 1, [FromQuery] int PageSize = 8)
        {
            var flowers = await _userFlowerService.GetMyFlowerCardsAsync(page, PageSize);
            return Ok(ApiResponse<List<MyFlowerCardDto>>.Ok(flowers));
        }

        [Authorize]
        [HttpPost("{id}/water")]
        public async Task<IActionResult> WaterFlowerAsync([FromQuery] int flowerId)
        {
            await _userFlowerService.WaterFlowerAsync(flowerId);
            return Ok(ApiResponse.Ok());
        }

        [Authorize]
        [HttpPost("{id}/fertilize")]
        public async Task<IActionResult> FertilizeFlowerAsync([FromQuery] int flowerId)
        {
            await _userFlowerService.FertilizeFlowerAsync(flowerId);
            return Ok(ApiResponse.Ok());
        }

        //TODO: separate in another controller
        [HttpGet("types")]
        public IActionResult GetFlowerTypes()
        {
            var types = _userFlowerService.GetFlowerTypes();
            return Ok(ApiResponse<List<string>>.Ok(types));
        }
    }
}
