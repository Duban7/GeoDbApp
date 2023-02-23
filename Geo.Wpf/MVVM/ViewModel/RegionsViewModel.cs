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
    public class RegionsViewModel
    {
        private readonly IRegionsRepository _regionsRepository;
        public ObservableCollection<Region> Regions { get; set; }
        public ICommand ShowMapsCommand { get; set; }
        public ICommand ShowRoutesCommand { get; set; }
        public RegionsViewModel(IRegionsRepository regionsRepository,
                                IWindowFactory windowFactory)
        {
            _regionsRepository = regionsRepository;
            Regions = _regionsRepository.GetAll();

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

            ShowRoutesCommand = new RelayCommand((o) =>
            {
                List<Route> route = (List<Route>)o!;
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

        }
    }
}
