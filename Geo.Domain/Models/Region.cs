namespace Geo.Domain.Models
{
    public class Region : ObservableObject
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

        string? country;
        public string? Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChange("Country");
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
