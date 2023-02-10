namespace Geo.Domain.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public List<Map> Maps { get; set; } = new();
        public List<Route> Routes { get; set; } = new();
    }
}
