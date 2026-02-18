using GreenCareApi.Application.DTOs.Requests;
using GreenCareApi.Domain.Entities.Flower;
using GreenCareApi.Domain.Enums;

namespace GreenCareApi.Application.Factories
{
    public static class UserFlowerFactory
    {
        public static UserFlower Create(CreateUserFlowerDto dto, string flowerImgPath, Guid creatorId)
        {
            return new UserFlower
            {
                Name = dto.Name,
                Description = dto.Description,
                Type = dto.Type,
                BloomSeason = dto.BloomSeasons.Aggregate(BloomSeasons.None, (acc, season) => acc | season),
                ImageUrl = flowerImgPath,
                CreatedAt = DateTime.UtcNow,
                //atributes
                WateringInterval = dto.WateringInterval,
                FertilizingInterval = dto.FertilizingInterval,
                OnModeration = !dto.IsPrivate,
                CreatorId = creatorId,
                IsPrivate = dto.IsPrivate
            };
        }
    }
}
