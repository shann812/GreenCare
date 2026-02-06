using GreenCareApi.Application.DTOs;
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
                Login = dto.Login,
                Email = dto.Email,
                PasswordHash = passwordHash,
                RegistrationDate = DateTime.UtcNow,
                UserName = dto.Login,
                RoleId = (int)RoleTypes.User
            };
        }
    }
}
