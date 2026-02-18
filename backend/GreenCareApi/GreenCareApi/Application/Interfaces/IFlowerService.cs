using GreenCareApi.Application.DTOs.Requests;

namespace GreenCareApi.Application.Interfaces
{
    public interface IFlowerService
    {
        Task CreateAsync(CreateUserFlowerDto dto, IFormFile flowerImg);
    }
}
