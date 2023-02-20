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
    public class MapsViewModel
    {
        private readonly IMapsRepository _mapsRepository;
        public ObservableCollection<Map>? Maps { get; private set; }
        public ICommand ShowRegionCommand { get; set; }
        public ICommand ShowRoutesCommand { get; set; } 
        public MapsViewModel(IMapsRepository mapsRepository) 
        {
            _mapsRepository = mapsRepository;
            Maps = _mapsRepository.GetAll();

            ShowRegionCommand = new RelayCommand((o) =>
            {
                Region? region = (Region)o!;
                if (region != null)
                {
                    MessageBox.Show(region.Name);
                }
            });

            ShowRoutesCommand = new RelayCommand((o) =>
            {
                StringBuilder stringBuilder = new();
                foreach (Route r in (List<Route>?)o!)
                {
                    if (r != null)
                    {
                        stringBuilder.Append(r.Name);
                        stringBuilder.Append('\n');
                    }
                }
                MessageBox.Show(stringBuilder.ToString());
            });

        }
    }
}
