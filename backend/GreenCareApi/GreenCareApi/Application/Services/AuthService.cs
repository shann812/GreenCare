using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.DTOs.Responses;
using GreenCareApi.Application.Interfaces;
using GreenCareApi.Domain.Exceptons;
using GreenCareApi.Infrastructure.Security;

namespace GreenCareApi.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtService _jwtService;
        public AuthService(IUserRepository userRepo, IJwtService jwtService) 
        { 
            _userRepo = userRepo;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _userRepo.GetByEmail(dto.Email);

            if (user is null)
                throw new BusinessException("Ivalid email or password");

            var isPasswordValid = PasswordHeasher.Verify(dto.Password, user.PasswordHash);

            var token = _jwtService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                RoleName = user.Role.Name,
                UserName = user.UserName
            };
        }
    }
}
