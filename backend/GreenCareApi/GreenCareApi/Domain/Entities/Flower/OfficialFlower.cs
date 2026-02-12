namespace GreenCareApi.Domain.Entities.Flower
{
    public class OfficialFlower
    {
        public string WateringSchedule { get; set; } = null!;
        public string FertilizingSchedule { get; set; } = null!;
        public string CreatedByAdminId { get; set; } = null!;
    }
}
