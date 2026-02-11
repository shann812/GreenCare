using GreenCareApi.Application.DTOs.Requests;

namespace GreenCareApi.Application.Interfaces
{
    public interface IUserService
    {
        Task RegistAsync(RegistrationUserDto dto);
    }
}
