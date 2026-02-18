namespace GreenCareApi.Domain.Entities.Flower
{
    public class OfficialFlower : FlowerBase
    {
        public string WateringSchedule { get; set; } = null!;
        public string FertilizingSchedule { get; set; } = null!;
        public string CreatedByAdminId { get; set; } = null!;
        public List<FlowerAttribute> Attributes { get; set; } = new();
    }
}