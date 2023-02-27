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
    public class RegionsViewModel
    {
        private readonly IRegionsRepository _regionsRepository;
        public ObservableCollection<Region> Regions { get; set; }
        public ICommand ShowMapsCommand { get; set; }
        public ICommand ShowRoutesCommand { get; set; }
        public ICommand AddRegionCommand { get; set; }
        public ICommand EditRegionCommand { get; set; }
        public ICommand DeleteRegionCommand { get; set; }
        public RegionsViewModel(IRegionsRepository regionsRepository,
                                IWindowFactory windowFactory)
        {
            _regionsRepository = regionsRepository;
            Regions = _regionsRepository.GetAll();

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

            ShowRoutesCommand = new RelayCommand((o) =>
            {
                ObservableCollection<Route> route = (ObservableCollection<Route>)o!;
                if (route.Count > 0)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(route.Cast<object>().ToList());
                    viewerWindow.ShowDialog();
                }
                else
                {
                    MessageWindow.Show("There is no route");
                }
            });

            AddRegionCommand = new RelayCommand((o) => 
            {
                RegionWindow regionWindow = windowFactory.Create<RegionWindow>()!;
                if (regionWindow.ShowDialog() == true)
                {
                    Region region = (regionWindow.DataContext as Region)!;
                    regionsRepository.Create(region);
                    Regions.Add(region);
                }
            });

            EditRegionCommand = new RelayCommand((o) =>
            {
                Region region = (Region)o!;
                if (region != null)
                {
                    RegionWindow regionWindow = windowFactory.Create<RegionWindow>()!;
                    regionWindow.AddData(region);
                    if (regionWindow.ShowDialog() == true)
                    {
                        regionsRepository.Update(region);
                    }
                }
            });

            DeleteRegionCommand = new RelayCommand((o) =>
            {
                if (MessageBoxResult.Yes == MessageWindow.Show("Deleting", "Are you sure want to delete?", MessageBoxButton.YesNo))
                {
                    Region region = (Region)o!;
                    if (region != null)
                    {
                        regionsRepository.Remove(region);
                        Regions.Remove(region);
                    }
                }
            });

        }
    }
}
