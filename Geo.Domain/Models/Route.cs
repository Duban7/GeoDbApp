namespace Geo.Domain.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? StartPoint { get; set; }
        public string? EndPoint { get; set; }
        public double Length { get; set; }
        public List<Map> Maps { get; set; } = new();
        public List<Region> Regions { get; set; } = new();
        public List<Expedition> Expeditions { get; set; } = new();

    }
}
