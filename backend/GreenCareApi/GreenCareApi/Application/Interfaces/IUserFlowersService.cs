using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.DTOs.Responses;

namespace GreenCareApi.Application.Interfaces
{
    public interface IUserFlowersService
    {
        Task CreateAsync(CreateUserFlowerDto dto);
        
        Task WaterFlowerAsync(int flowerId);
        Task FertilizeFlowerAsync(int flowerId);

        Task<List<MyFlowerCardDto>> GetMyFlowerCardsAsync(int page, int pageSize);
        List<string> GetFlowerTypes();
    }
}
