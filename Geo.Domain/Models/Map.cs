namespace Geo.Domain.Models
{
    public class Map : ObservableObject
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

        string? type;
        public string? Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChange("Type");
            }
        }

        int regionId;
        public int RegionId
        {
            get { return regionId; }
            set
            {
                regionId = value;
                OnPropertyChange("RegionId");
            }
        }

        Region? region;
        public Region? Region
        {
            get { return region; }
            set
            {
                region = value;
                OnPropertyChange("Region");
            }
        }

        List<Route>? routes;
        public List<Route> Routes
        {
            get { return routes != null ? routes : new(); }
            set
            {
                routes = value;
                OnPropertyChange("Routes");
            }
        }
    }
}
