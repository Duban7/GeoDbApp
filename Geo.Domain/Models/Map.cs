namespace Geo.Domain.Models
{
    public class Map
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int RegionId { get; set; }
        public Region? Region { get; set; }
        public List<Route> Routes { get; set; } = new();
    }
}
