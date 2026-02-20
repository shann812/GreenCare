using GreenCareApi.Application.Interfaces;
using GreenCareApi.Domain.Entities.Flower;
using Microsoft.EntityFrameworkCore;

namespace GreenCareApi.Infrastructure.Repositories
{
    public class UserFlowerRepositoty : IUserFlowerRepository
    {
        private readonly ApplicationDbContext _db;
        public UserFlowerRepositoty(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(FlowerBase flower)
            =>_db.Flowers.Add(flower);

        public Task<List<UserFlower>> GetUserFlowersAsync(Guid userId, int page, int pageSize)
        {
            return _db.Flowers
                .OfType<UserFlower>()
                .Where(f => f.CreatorId == userId)
                .OrderByDescending(f => f.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        //almoust same GetUserPublicFlowersAsync
    }
}
