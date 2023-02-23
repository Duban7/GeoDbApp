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
    public class RoutesViewModel
    {
        private readonly IRoutesRepository _routesRepository;
        public ObservableCollection<Route> Routes { get; private set; }
        public ICommand ShowMapsCommand { get; set; }
        public ICommand ShowRegionsCommand { get; set; }
        public ICommand ShowExpeditionsCommand { get; set; }

        public RoutesViewModel(IRoutesRepository routesRepository,
                               IWindowFactory windowFactory)
        {
            _routesRepository = routesRepository;
            Routes = _routesRepository.GetAll();

            ShowMapsCommand = new RelayCommand((o) =>
            {
                List<Map> maps = (List<Map>)o!;
                if (maps.Count > 0)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(maps.Cast<object>().ToList());
                    viewerWindow.ShowDialog();
                }
                else
                {
                    MessageWindow.Show("There is no maps");
                }
            });

            ShowRegionsCommand = new RelayCommand((o) =>
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

            ShowExpeditionsCommand = new RelayCommand((o) =>
            {
                List<Expedition> expeditions = (List<Expedition>)o!;
                if (expeditions.Count > 0)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(expeditions.Cast<object>().ToList());
                    viewerWindow.ShowDialog();
                }
                else
                {
                    MessageWindow.Show("There is no expeditions");
                }
            });
        }
    }
}
