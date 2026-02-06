using GreenCareApi.Application.DTOs;

namespace GreenCareApi.Application.Interfaces
{
    public interface IUserService
    {
        Task RegistAsync(RegistrationUserDto dto);
    }
}
