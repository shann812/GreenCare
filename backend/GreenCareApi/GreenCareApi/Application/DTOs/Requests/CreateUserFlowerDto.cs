using GreenCareApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace GreenCareApi.Application.DTOs.Requests
{
    public class CreateUserFlowerDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public FlowerTypes Type { get; set; }

        public List<BloomSeasons> BloomSeasons { get; set; } = new();

        [Range(1, 365)]
        public int? WateringInterval { get; set; }
        [Range(1, 365)]
        public int? FertilizingInterval { get; set; }
        public bool IsPrivate { get; set; }

        //Attributes
    }
}
