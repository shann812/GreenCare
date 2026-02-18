using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.Factories;
using GreenCareApi.Application.Interfaces;

namespace GreenCareApi.Application.Services
{
    public class FlowerService : IFlowerService
    {
        private readonly IFileUploaderService _fileUploaderService;
        private readonly IUserContextService _userContextService;
        public FlowerService(IFileUploaderService imgService, IUserContextService userContextService)
        {
            _fileUploaderService = imgService;
            _userContextService = userContextService;
        }

        public async Task CreateAsync(CreateUserFlowerDto dto, IFormFile flowerImg)
        {
            var flowerImgPath = (flowerImg != null) 
                ? await _fileUploaderService.SaveImage("flowers", flowerImg) 
                : _fileUploaderService.GetNoImagePath();

            var creatorId = _userContextService.GetUserId();
            var flower = UserFlowerFactory.Create(dto, flowerImgPath, creatorId);
        }
    }
}
