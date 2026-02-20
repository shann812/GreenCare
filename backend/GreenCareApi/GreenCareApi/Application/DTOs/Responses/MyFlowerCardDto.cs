namespace GreenCareApi.Application.DTOs.Responses
{
    public class MyFlowerCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public bool IsPrivate { get; set; }
        public bool OnModeration { get; set; }

        public DateTime? LastWatering { get; set; }
        public int WateringIntervalDays { get; set; }

        public DateTime? LastFertilizing { get; set; }
        public int FertilizingIntervalDays { get; set; }

    }
}
