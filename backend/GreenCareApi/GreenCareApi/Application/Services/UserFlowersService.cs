using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.DTOs.Responses;
using GreenCareApi.Application.Factories;
using GreenCareApi.Application.Interfaces;
using GreenCareApi.Domain.Entities;
using GreenCareApi.Domain.Entities.Flower;
using GreenCareApi.Domain.Enums;
using GreenCareApi.Domain.Exceptons;

namespace GreenCareApi.Application.Services
{
    public class UserFlowersService : IUserFlowersService
    {
        private readonly IFileUploaderService _fileUploaderService;
        private readonly IUserContextService _userContextService;
        private readonly IUserFlowerRepository _userFlowerRepo;
        private readonly IUnitOfWork _unitOfWork;
        public UserFlowersService(IFileUploaderService imgService, IUserContextService userContextService, IUserFlowerRepository userFlowerRepo, IUnitOfWork unitOfWork)
        {
            _fileUploaderService = imgService;
            _userContextService = userContextService;
            _userFlowerRepo = userFlowerRepo;
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
                _userFlowerRepo.Add(flower);
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

        public async Task<List<MyFlowerCardDto>> GetMyFlowerCardsAsync(int page, int pageSize)
        {
            var userId = _userContextService.GetUserId();
            var flowers = await _userFlowerRepo.GetUserFlowersAsync(userId, page, pageSize);
            return flowers.Select(FlowerCardFactory.ToMyFlowerCardDto).ToList();
        }

        public List<string> GetFlowerTypes()
        {
            var types = Enum.GetNames(typeof(FlowerTypes)).OrderBy(t => t).ToList();
            return types; 
        }

        public async Task WaterFlowerAsync(int flowerId)
        {
            var flower = await GetOwnedFlowerAsync(flowerId);
            flower.LastWateringDate = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task FertilizeFlowerAsync(int flowerId)
        {
            var flower = await GetOwnedFlowerAsync(flowerId);
            flower.LastFertilizingDate = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<UserFlower> GetOwnedFlowerAsync(int flowerId)
        {
            var userId = _userContextService.GetUserId();
            var flower = await _userFlowerRepo.GetById(flowerId);

            if (flower is null)
                throw new BusinessException($"There are no flower with id {flowerId}.");

            if (flower.CreatorId != userId)
                throw new UnauthorizedAccessException("You can only fertilizing your own flowers.");

            return flower;
        }
    }
}
