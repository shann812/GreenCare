using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Application.Factories;
using GreenCareApi.Application.Interfaces;
using GreenCareApi.Domain.Exceptons;
using GreenCareApi.Infrastructure.Security;

namespace GreenCareApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task RegistAsync(RegistrationUserDto dto)
        {
            var exist = await _userRepo.GetByEmail(dto.Email);
            if (exist != null)
                throw new BusinessException("User with this email already exist");

            var passwordHash = PasswordHeasher.HashPassword(dto.Password);
            var user = UserRegistrationFactory.Create(dto, passwordHash);

            _userRepo.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
