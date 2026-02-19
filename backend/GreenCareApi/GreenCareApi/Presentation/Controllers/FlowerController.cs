using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.Interfaces;
using GreenCareApi.Presentation.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenCareApi.Presentation.Controllers
{
    [Route("api/flower")]
    public class FlowerController : Controller
    {
        private readonly IFlowerService _flowerService;
        public FlowerController(IFlowerService flowerService)
        {
            _flowerService = flowerService;
        }

        [Authorize]
        [HttpPost("create")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateFlowerAsync([FromForm] CreateUserFlowerDto dto)
        {
            await _flowerService.CreateAsync(dto);
            return Ok(ApiResponse.Ok());
        }

        [HttpGet("types")]
        public IActionResult GetFlowerTypesAsync()
        {
            var types = _flowerService.GetFlowerTypes();
            return Ok(ApiResponse<List<string>>.Ok(types));
        }
    }
}
