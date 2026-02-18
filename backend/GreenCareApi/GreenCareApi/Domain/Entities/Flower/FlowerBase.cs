using GreenCareApi.Domain.Enums;

namespace GreenCareApi.Domain.Entities.Flower
{
    public abstract class FlowerBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = "No description provided";

        public FlowerTypes Type { get; set; }
        public BloomSeasons BloomSeason { get; set; }

        public string? ImageUrl { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? AttributesJson { get; set; } = null!;
    }
}
