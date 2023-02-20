using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Geo.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Geo.Wpf.MVVM.ViewModel
{
    public class RoutesViewModel
    {
        private readonly IRoutesRepository _routesRepository;
        public ObservableCollection<Route> Routes { get; private set; }
        public ICommand ShowMapsCommand { get; set; }
        public ICommand ShowRegionsCommand { get; set; }
        public ICommand ShowExpeditionsCommand { get; set; }

        public RoutesViewModel(IRoutesRepository routesRepository)
        {
            _routesRepository = routesRepository;
            Routes = _routesRepository.GetAll();

            ShowMapsCommand = new RelayCommand((o) =>
            {
                StringBuilder stringBuilder = new();
                foreach (Map m in (List<Map>?)o!)
                {
                    if (m != null)
                    {
                        stringBuilder.Append(m.Name);
                        stringBuilder.Append('\n');
                    }
                }
                MessageBox.Show(stringBuilder.ToString());
            });

            ShowRegionsCommand = new RelayCommand((o) =>
            {
                StringBuilder stringBuilder = new();
                foreach (Region r in (List<Region>?)o!)
                {
                    if (r != null)
                    {
                        stringBuilder.Append(r.Name);
                        stringBuilder.Append(' ');
                        stringBuilder.Append(r.Country);
                        stringBuilder.Append('\n');
                    }
                }
                MessageBox.Show(stringBuilder.ToString());
            });

            ShowExpeditionsCommand = new RelayCommand((o) =>
            {
                StringBuilder stringBuilder = new();
                foreach (Expedition ex in (List<Expedition>?)o!)
                {
                    if (ex != null)
                    {
                        stringBuilder.Append(ex.Name);
                        stringBuilder.Append(' ');
                        stringBuilder.Append(ex.Date.ToShortDateString());
                        stringBuilder.Append('\n');
                    }
                }
                MessageBox.Show(stringBuilder.ToString());
            });
        }
    }
}
