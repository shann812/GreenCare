using GreenCareApi.Application.Interfaces;

namespace GreenCareApi.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SaveChangesAsync()
            => await _db.SaveChangesAsync();
    }
}
