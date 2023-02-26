using System.Collections.ObjectModel;

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

        ObservableCollection<Route>? routes;
        public ObservableCollection<Route> Routes
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
