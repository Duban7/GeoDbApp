using Geo.DAL.repositories.implementation;
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
        public ICommand AddRouteCommand { get; set; }
        public ICommand EditRouteCommand { get; set; }
        public ICommand DeleteRouteCommand { get; set; }
        public RoutesViewModel(IRoutesRepository routesRepository,
                               IWindowFactory windowFactory)
        {
            _routesRepository = routesRepository;
            Routes = _routesRepository.GetAll();

            ShowMapsCommand = new RelayCommand((o) =>
            {
                ObservableCollection<Map> maps = (ObservableCollection<Map>)o!;
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
                ObservableCollection<Region> regions = (ObservableCollection<Region>)o!;
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
                ObservableCollection<Expedition> expeditions = (ObservableCollection<Expedition>)o!;
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

            AddRouteCommand = new RelayCommand((o) => 
            {

            });

            EditRouteCommand = new RelayCommand((o) =>
            {
                //add edit handling
            });

            DeleteRouteCommand = new RelayCommand((o) =>
            {
                if (MessageBoxResult.Yes == MessageWindow.Show("Deleting", "Are you sure want to delete?", MessageBoxButton.YesNo))
                {
                    Route route = (Route)o!;
                    if (route != null)
                    {
                        routesRepository.Remove(route);
                        Routes.Remove(route);
                    }
                }
            });
        }
    }
}
