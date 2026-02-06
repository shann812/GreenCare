using GreenCareApi.Domain.Entities;

namespace GreenCareApi.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
