namespace Geo.Domain.Models
{
    public class Expedition : ObservableObject
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

        DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChange("Date");
            }
        }

        List<Geologist>? geologists;
        public List<Geologist> Geologists
        {
            get { return geologists != null ? geologists : new(); }
            set
            {
                geologists = value;
                OnPropertyChange("Geologists");
            }
        }

        int routeID;
        public int RouteID
        {
            get { return routeID; }
            set
            {
                routeID = value;
                OnPropertyChange("RouteID");
            }
        }

        Route? route;
        public Route? Route
        {
            get { return route; }
            set
            {
                route = value;
                OnPropertyChange("Route");
            }
        }
    }
}
