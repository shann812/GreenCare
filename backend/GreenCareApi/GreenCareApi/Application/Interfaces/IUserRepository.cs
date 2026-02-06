using GreenCareApi.Domain.Entities;

namespace GreenCareApi.Application.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(User user);
        Task<User?> GetById(Guid id);
        Task<User?> GetByEmail(string email);
    }
}
