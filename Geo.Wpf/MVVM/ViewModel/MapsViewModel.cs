using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Geo.Wpf.Core;
using Geo.Wpf.WindowFactory.Interfaces;
using Geo.Wpf.Windows;
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
        public MapsViewModel(IMapsRepository mapsRepository,
                             IWindowFactory windowFactory) 
        {
            _mapsRepository = mapsRepository;
            Maps = _mapsRepository.GetAll();

            ShowRegionCommand = new RelayCommand((o) =>
            {
                List<Region> regions = (List<Region>)o!;
                if (regions.Count > 0)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(regions.Cast<object>().ToList());
                    viewerWindow.ShowDialog();
                }
                else
                {
                    MessageWindow.Show("There is no regions");
                }
            });

            ShowRoutesCommand = new RelayCommand((o) =>
            {
                List<Route> routes = (List<Route>)o!;
                if (routes.Count > 0)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(routes.Cast<object>().ToList());
                    viewerWindow.ShowDialog();
                }
                else
                {
                    MessageWindow.Show("There is no routes");
                }
            });

        }
    }
}
