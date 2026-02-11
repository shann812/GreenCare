using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Domain.Entities;
using GreenCareApi.Domain.Enums;

namespace GreenCareApi.Application.Factories
{
    public static class UserRegistrationFactory
    {
        public static User Create(RegistrationUserDto dto, string passwordHash)
        {
            return new User
            {
                Email = dto.Email,
                PasswordHash = passwordHash,
                RegistrationDate = DateTime.UtcNow,
                RoleId = (int)RoleTypes.User
            };
        }
    }
}
