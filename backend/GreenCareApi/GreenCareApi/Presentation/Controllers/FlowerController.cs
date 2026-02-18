using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.Interfaces;
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
        public async Task<IActionResult> CreateFlowerAsync(CreateUserFlowerDto dto, IFormFile flowerImg)
        {
            await _flowerService.CreateAsync(dto, flowerImg);
            return Ok();
        }
    }
}
