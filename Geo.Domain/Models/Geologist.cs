namespace Geo.Domain.Models
{
    public class Geologist : ObservableObject
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

        string? surname;
        public string? Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChange("Surname");
            }
        }

        string? patronymic;
        public string? Patronymic
        {
            get { return patronymic; }
            set
            {
                patronymic = value;
                OnPropertyChange("Patronymic");
            }
        }

        string? state;
        public string? State
        {
            get { return state != null ? state : GeologistState.Free; }
            set
            {
                state = value;
                OnPropertyChange("State");
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
    public static class GeologistState
    {
        public static readonly string Busy = "Busy";
        public static readonly string Free = "Free";
        public static readonly List<string> States = new List<string>() { GeologistState.Busy, GeologistState.Free };
    }
}
