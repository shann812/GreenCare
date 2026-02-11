using GreenCareApi.Application.Interfaces;
using GreenCareApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenCareApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(User user)
            => _db.Users.Add(user);

        public void Delete(User user)
            => _db.Users.Remove(user);

        public async Task<User?> GetById(Guid id)
            => await _db.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User?> GetByEmail(string email)
            => await _db.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
    }
}
