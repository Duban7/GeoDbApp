using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geo.Domain.Models
{
    public class PlannedExpedition : ObservableObject
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
