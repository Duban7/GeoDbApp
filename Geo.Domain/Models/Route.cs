namespace Geo.Domain.Models
{
    public class Route : ObservableObject
    {
        int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChange("Id");
            }
        }

        string? name;
        public string? Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChange("Name");
            }
        }

        string? startPoint;
        public string? StartPoint
        {
            get { return startPoint; }
            set
            {
                startPoint = value;
                OnPropertyChange("StartPoint");
            }
        }

        string? endPoint;
        public string? EndPoint
        {
            get { return endPoint; }
            set
            {
                endPoint = value;
                OnPropertyChange("EndPoint");
            }
        }

        double length;
        public double Length
        {
            get { return length; }
            set
            {
                length = value;
                OnPropertyChange("Length");
            }
        }

        List<Map>? maps;
        public List<Map> Maps
        {
            get { return maps != null ? maps : new(); }
            set
            {
                maps = value;
                OnPropertyChange("Maps");
            }
        }

        List<Region>? regions;
        public List<Region> Regions
        {
            get { return regions != null ? regions : new(); }
            set
            {
                regions = value;
                OnPropertyChange("Regions");
            }
        }

        List<Expedition>? expeditions;
        public List<Expedition> Expeditions
        {
            get { return expeditions != null ? expeditions : new(); }
            set
            {
                expeditions = value;
                OnPropertyChange("Expeditions");
            }
        }
    }
}
