﻿namespace Geo.Domain.Models
{
    public class Expedition
    {
        public int Id { get; set; }
        public string? Name { get; set; }    
        public DateTime Date { get; set; }
        public List<Geologist> Geologists { get; set; } = new();
        public int RouteID { get; set; }   
        public Route? Route { get; set; }
    }
}