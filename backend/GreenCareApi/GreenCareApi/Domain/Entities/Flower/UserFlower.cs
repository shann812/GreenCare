namespace GreenCareApi.Domain.Entities.Flower
{
    public class UserFlower : FlowerBase
    {
        public DateTime? LastWateringDate { get; set; }
        public int? WateringInterval { get; set; }
        public DateTime? LastFertilizingDate { get; set; }
        public int? FertilizingInterval { get; set; }
        public bool? OnModeration { get; set; } = true;
        public Guid? CreatorId { get; set; }
        public User Creator { get; set; }
        public bool IsPrivate { get; set; }
    }
}