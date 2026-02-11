using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.DTOs.Responses;

namespace GreenCareApi.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto dto);
    }
}
