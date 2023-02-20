using Geo.Domain.Models;
using Geo.Wpf.Core;
using Geo.Wpf.MVVM.View;
using System.Windows;
using System.Windows.Input;

namespace Geo.Wpf.MVVM.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainViewModel MainViewModel { get; set; }
        public ExpeditionsViewModel ExpeditionsViewModel { get; set; }
        public GeologistsViewModel GeologistsViewModel { get; set; }
        public ICommand MainViewCommand { get; set; }
        public ICommand ExpeditionsViewCommand { get; set; }
        public ICommand GeologistsViewCommand { get; set; }

        private object? _currentView;
        public object? CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView= value;
                OnPropertyChange("CurrentView");
            }
        }
        public MainWindowViewModel(MainViewModel mainViewModel, ExpeditionsViewModel expeditionsViewModel, GeologistsViewModel geologistsViewModel)
        {
            MainViewModel = mainViewModel;
            ExpeditionsViewModel = expeditionsViewModel;
            GeologistsViewModel = geologistsViewModel;

            CurrentView = MainViewModel;

            MainViewCommand = new RelayCommand((o) => 
            {
                CurrentView = MainViewModel;
            });
            
            ExpeditionsViewCommand = new RelayCommand((o) =>
            {
                CurrentView = ExpeditionsViewModel;
            });

            GeologistsViewCommand = new RelayCommand((o) =>
            {
                CurrentView = GeologistsViewModel;
            });
        }
    }
}
