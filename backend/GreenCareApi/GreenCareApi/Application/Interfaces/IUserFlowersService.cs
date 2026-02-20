using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.DTOs.Responses;

namespace GreenCareApi.Application.Interfaces
{
    public interface IUserFlowersService
    {
        Task CreateAsync(CreateUserFlowerDto dto);
        List<string> GetFlowerTypes();
        Task<List<MyFlowerCardDto>> GetMyFlowerCardsAsync(int page, int pageSize);
    }
}
