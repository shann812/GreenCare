using GreenCareApi.Application.DTOs.Responses;
using GreenCareApi.Domain.Entities.Flower;

namespace GreenCareApi.Application.Factories
{
    public static class FlowerCardFactory
    {
        public static MyFlowerCardDto ToMyFlowerCardDto(UserFlower flower)
        {
            return new MyFlowerCardDto
            {
                Id = flower.Id,
                Name = flower.Name,
                Type = flower.Type.ToString(),
                ImageUrl = flower.ImageUrl,
                IsPrivate = flower.IsPrivate,
                OnModeration = flower.OnModeration ?? !flower.IsPrivate,
                LastWatering = flower.LastWateringDate,
                WateringIntervalDays = flower.WateringIntervalDays ?? 0,
                LastFertilizing = flower.LastFertilizingDate,
                FertilizingIntervalDays = flower.FertilizingIntervalDays ?? 0
            };
        }
    }
}
