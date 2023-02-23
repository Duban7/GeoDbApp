using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Geo.Wpf.Core;
using Geo.Wpf.WindowFactory.Interfaces;
using Geo.Wpf.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Geo.Wpf.MVVM.ViewModel
{
    public class ExpeditionsViewModel
    {
        private readonly IExpeditionsRepository _expeditionsRepository; 
        public ObservableCollection<Expedition> Expeditions { get; private set; }
        public ICommand ShowGeologistsCommand { get; set; }
        public ICommand ShowRouteCommand { get; set; }
        public ExpeditionsViewModel(IExpeditionsRepository expeditionsRepository,
                                    IWindowFactory windowFactory)
        {
            _expeditionsRepository = expeditionsRepository;
            Expeditions = _expeditionsRepository.GetAll();
            ShowGeologistsCommand = new RelayCommand((o) =>
            {
                List<Geologist> geologists = (List<Geologist>)o!;
                if (geologists.Count > 0)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(geologists.Cast<object>().ToList());
                    viewerWindow.ShowDialog();
                }
                else
                {
                    MessageWindow.Show("There is no geologists");
                }
            });

            ShowRouteCommand = new RelayCommand((o) =>
            {
                if (o != null)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(new List<object>() { o });
                    viewerWindow.ShowDialog();
                }
            });
        }
    }
}
