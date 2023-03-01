using Geo.DAL.repositories.implementation;
using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Geo.Wpf.Core;
using Geo.Wpf.WindowFactory.Interfaces;
using Geo.Wpf.Windows;
using Geo.Wpf.Windows.ModelsWindows;
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
        public ICommand AddMapCommand { get; set; }
        public ICommand EditMapCommand { get; set; }
        public ICommand DeleteMapCommand { get; set; }
        public MapsViewModel(IMapsRepository mapsRepository,
                             IRegionsRepository regionsRepository,
                             IWindowFactory windowFactory) 
        {
            _mapsRepository = mapsRepository;
            Maps = _mapsRepository.GetAll();

            ShowRegionCommand = new RelayCommand((o) =>
            {

                if ((o as Region) != null)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(new List<object>() {o!});
                    viewerWindow.ShowDialog();
                }
                else
                {
                    MessageWindow.Show("There is no regions");
                }
            });

            ShowRoutesCommand = new RelayCommand((o) =>
            {
                ObservableCollection<Route> routes = (ObservableCollection<Route>)o!;
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

            AddMapCommand = new RelayCommand((o) => 
            {
                MapsWindow mapsWindow = windowFactory.Create<MapsWindow>()!;
                mapsWindow.AddData(regionsRepository.GetAll());
                if (mapsWindow.ShowDialog() == true)
                {
                    Map map = (mapsWindow.DataContext as Map)!;
                    mapsRepository.Create(map);
                    Maps.Add(map);
                }
            });

            EditMapCommand = new RelayCommand((o) =>
            {
                
                Map map = (Map)o!;
                if (map != null)
                {
                    MapsWindow mapsWindow = windowFactory.Create<MapsWindow>()!;
                    mapsWindow.AddData(regionsRepository.GetAll(), map);
                    if(mapsWindow.ShowDialog() == true)
                    {
                        mapsRepository.Update(map);
                    }
                }
            });

            DeleteMapCommand = new RelayCommand((o) =>
            {
                if (MessageBoxResult.Yes == MessageWindow.Show("Deleting", "Are you sure want to delete?", MessageBoxButton.YesNo))
                {
                    Map map = (Map)o!;
                    if (map != null)
                    {
                        mapsRepository.Remove(map);
                        Maps.Remove(map);
                    }
                }
            });
        }
    }
}
