using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.Factories;
using GreenCareApi.Application.Interfaces;
using GreenCareApi.Domain.Enums;

namespace GreenCareApi.Application.Services
{
    public class FlowerService : IFlowerService
    {
        private readonly IFileUploaderService _fileUploaderService;
        private readonly IUserContextService _userContextService;
        private readonly IFlowerRepository _flowerRepo;
        private readonly IUnitOfWork _unitOfWork;
        public FlowerService(IFileUploaderService imgService, IUserContextService userContextService, IFlowerRepository flowerRepo, IUnitOfWork unitOfWork)
        {
            _fileUploaderService = imgService;
            _userContextService = userContextService;
            _flowerRepo = flowerRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateUserFlowerDto dto)
        {
            string? flowerImgPath = null;
            try
            {
                flowerImgPath = (dto.FlowerImg != null)
                ? await _fileUploaderService.SaveImage("flowers", dto.FlowerImg)
                : _fileUploaderService.GetNoImagePath();

                var creatorId = _userContextService.GetUserId();
                var flower = UserFlowerFactory.Create(dto, flowerImgPath, creatorId);
                _flowerRepo.Add(flower);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                if (flowerImgPath != null && flowerImgPath != _fileUploaderService.GetNoImagePath())
                {
                    _fileUploaderService.DeleteImage(flowerImgPath);
                }
                throw;
            }
        }

        public List<string> GetFlowerTypes()
        {
            var types = Enum.GetNames(typeof(FlowerTypes)).ToList();
            return types; 
        }
    }
}
