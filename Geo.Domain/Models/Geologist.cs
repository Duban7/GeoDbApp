namespace Geo.Domain.Models
{
    public class Geologist
    {
        public int Id { get; set; } 
        public string? Name { get; set; }   
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? State { get; set; } = GeologistState.Free;
        public List<Expedition> Expeditions { get; set; } = new();
    }
    public static class GeologistState
    {
        public static readonly string Busy = "Busy";
        public static readonly string Free = "Free";
    }
}
