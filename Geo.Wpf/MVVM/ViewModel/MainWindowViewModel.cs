using Geo.Domain.Models;
using Geo.Wpf.Core;
using System.Windows.Input;

namespace Geo.Wpf.MVVM.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainViewModel MainViewModel { get; set; }
        public ExpeditionsViewModel ExpeditionsViewModel { get; set; }
        public ICommand MainViewCommand { get; set; }
        public ICommand ExpeditionsViewCommand { get; set; }

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
        public MainWindowViewModel(MainViewModel mainViewModel, ExpeditionsViewModel expeditionsViewModel)
        {
            MainViewModel = mainViewModel;
            ExpeditionsViewModel = expeditionsViewModel;
            
            MainViewCommand = new RelayCommand((o) => 
            {
                CurrentView = MainViewModel;
            });
            
            ExpeditionsViewCommand = new RelayCommand((o) =>
            {
                CurrentView = ExpeditionsViewModel;
            });

        }
    }
}
