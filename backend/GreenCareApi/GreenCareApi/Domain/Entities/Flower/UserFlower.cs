namespace GreenCareApi.Domain.Entities.Flower
{
    public class UserFlower : FlowerBase
    {
        public DateTime? LastWateringDate { get; set; }
        public int? WateringIntervalDays { get; set; }

        public DateTime? LastFertilizingDate { get; set; }
        public int? FertilizingIntervalDays { get; set; }

        public bool? OnModeration { get; set; } = true;
        public Guid? CreatorId { get; set; }
        public User Creator { get; set; }
        public bool IsPrivate { get; set; }
    }
}