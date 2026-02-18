namespace GreenCareApi.Domain.Entities.Flower
{
    public class FlowerAttribute
    {
        public int Id { get; set; }

        public int FlowerId { get; set; }
        public OfficialFlower OfficialFlower { get; set; } = null!;

        public string AttributeName { get; set; } = null!;
        public string AttributeValue { get; set; } = null!;
    }
}
