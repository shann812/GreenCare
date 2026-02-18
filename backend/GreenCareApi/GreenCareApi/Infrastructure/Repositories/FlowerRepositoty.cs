using GreenCareApi.Application.Interfaces;
using GreenCareApi.Domain.Entities.Flower;

namespace GreenCareApi.Infrastructure.Repositories
{
    public class FlowerRepositoty : IFlowerRepository
    {
        private readonly ApplicationDbContext _db;
        public FlowerRepositoty(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(FlowerBase flower)
            =>_db.Flowers.Add(flower);
    }
}
