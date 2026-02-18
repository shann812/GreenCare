using GreenCareApi.Domain.Entities.Flower;

namespace GreenCareApi.Application.Interfaces
{
    public interface IFlowerRepository
    {
        void Add(FlowerBase flower);
    }
}
