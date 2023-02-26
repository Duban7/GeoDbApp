using System.Collections.ObjectModel;

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

        ObservableCollection<Map>? maps;
        public ObservableCollection<Map> Maps
        {
            get { return maps != null ? maps : new(); }
            set
            {
                maps = value;
                OnPropertyChange("Maps");
            }
        }

        ObservableCollection<Region>? regions;
        public ObservableCollection<Region> Regions
        {
            get { return regions != null ? regions : new(); }
            set
            {
                regions = value;
                OnPropertyChange("Regions");
            }
        }

        ObservableCollection<Expedition>? expeditions;
        public ObservableCollection<Expedition> Expeditions
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
