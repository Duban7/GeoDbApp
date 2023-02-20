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
    public class RegionsViewModel
    {
        private readonly IRegionsRepository _regionsRepository;
        public ObservableCollection<Region> Regions { get; set; }
        public ICommand ShowMapsCommand { get; set; }
        public ICommand ShowRoutesCommand { get; set; }
        public RegionsViewModel(IRegionsRepository regionsRepository)
        {
            _regionsRepository = regionsRepository;
            Regions = _regionsRepository.GetAll();

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

            ShowRoutesCommand = new RelayCommand((o) =>
            {
                StringBuilder stringBuilder = new();
                foreach (Route r in (List<Route>?)o!)
                {
                    if (r != null)
                    {
                        stringBuilder.Append(r.Name);
                        stringBuilder.Append(' ');
                        stringBuilder.Append(r.StartPoint);
                        stringBuilder.Append(' ');
                        stringBuilder.Append(r.EndPoint);
                        stringBuilder.Append('\n');
                    }
                }
                MessageBox.Show(stringBuilder.ToString());

            });

        }
    }
}
