namespace Geo.Domain.Models
{
    public class Expedition
    {
        public int ID { get; set; }
        public string? Name { get; set; }    
        public DateTime Date { get; set; }
        public List<Geologist> Geologists { get; set; } = new();
        public List<Route> Routes { get; set; } = new();
    }
}
