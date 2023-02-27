using Geo.DAL.repositories.implementation;
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
        public ObservableCollection<Expedition> Expeditions { get; private set; }
        public ICommand ShowGeologistsCommand { get; set; }
        public ICommand ShowRouteCommand { get; set; }
        public ICommand AddExpeditionCommand { get; set; }
        public ICommand EditExpeditionCommand { get; set; }
        public ICommand DeleteExpeditionCommand { get; set; }
        public ICommand ShowPlannedExpeditionsCommand { get; set; }
        public ExpeditionsViewModel(IExpeditionsRepository expeditionsRepository,
                                    IRoutesRepository routesRepository,
                                    IGeologistsRepository geologistsRepository,
                                    IPlannedExpeditionsRepository plannedExpeditionsRepository,
                                    IWindowFactory windowFactory)
        {
            Expeditions = expeditionsRepository.GetAll();
            ShowGeologistsCommand = new RelayCommand((o) =>
            {
                ObservableCollection<Geologist> geologists = (ObservableCollection<Geologist>)o!;
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
                if ((o as Route) != null)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(new List<object>() { o });
                    viewerWindow.ShowDialog();
                }
            });

            AddExpeditionCommand = new RelayCommand((o) => 
            {
                ExpeditionWindow expeditionWindow = windowFactory.Create<ExpeditionWindow>()!;
                expeditionWindow.AddData(routesRepository.GetAll(),
                                         geologistsRepository.GetAll());
                if (expeditionWindow.ShowDialog() == true)
                {
                    if(expeditionWindow.DataContext is Expedition)
                    {
                        Expedition expedition = (expeditionWindow.DataContext as Expedition)!;
                        expeditionsRepository.Create(expedition);
                        Expeditions.Add(expedition);
                    }

                    if(expeditionWindow.DataContext is PlannedExpedition)
                    {
                        PlannedExpedition plannedExpedition = (expeditionWindow.DataContext as PlannedExpedition)!;
                        plannedExpeditionsRepository.Create(plannedExpedition);
                    }
                }
            });

            EditExpeditionCommand = new RelayCommand((o) => 
            {
                Expedition expedition = (Expedition)o!;
                if (expedition != null)
                {

                    ExpeditionWindow expeditionWindow = windowFactory.Create<ExpeditionWindow>()!;
                    expeditionWindow.AddData(expedition,
                                             routesRepository.GetAll(),
                                             geologistsRepository.GetAll());
                    if (expeditionWindow.ShowDialog() == true)
                    {
                        //expedition = (expeditionWindow.DataContext as Expedition)!;
                        expeditionsRepository.Update(expedition);
                    }
                }
            });

            DeleteExpeditionCommand = new RelayCommand((o) =>
            {
                if (MessageBoxResult.Yes == MessageWindow.Show("Deleting", "Are you sure want to delete?", MessageBoxButton.YesNo))
                {
                    Expedition expedition = (Expedition)o!;
                    if (expedition != null)
                    {
                        expeditionsRepository.Remove(expedition);
                        Expeditions.Remove(expedition);
                    }
                }
            });

            ShowPlannedExpeditionsCommand = new RelayCommand((o) => 
            {
                ObservableCollection<PlannedExpedition> plannedExpeditions = plannedExpeditionsRepository.GetAll();
                if (plannedExpeditions.Count > 0)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(plannedExpeditions.ToList<object>());
                    viewerWindow.ShowDialog();
                }
                else MessageWindow.Show("There is no planned expeditions");
            });
        }
    }
}
