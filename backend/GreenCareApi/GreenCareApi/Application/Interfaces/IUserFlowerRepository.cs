using GreenCareApi.Domain.Entities.Flower;

namespace GreenCareApi.Application.Interfaces
{
    public interface IUserFlowerRepository
    {
        void Add(FlowerBase flower);
        Task<List<UserFlower>> GetUserFlowersAsync(Guid userId, int page, int pageSize);
    }
}
