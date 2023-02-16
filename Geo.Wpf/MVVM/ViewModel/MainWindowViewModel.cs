using Geo.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geo.Wpf.MVVM.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainViewModel MainViewModel { get; set; }
        public ExpeditionsViewModel ExpeditionsViewModel { get; set; }
        public RelayCommand MainViewCommand { get; set; }
        public RelayCommand ExpeditionsViewCommand { get; set; }

        private object? _currentView;
        public object? CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView= value;
                OnPropertyChange();
            }
        }
        public MainWindowViewModel()
        {
            MainViewModel= new MainViewModel();
            ExpeditionsViewModel = new ExpeditionsViewModel();
            MainViewCommand = new RelayCommand((o) => 
            {
                CurrentView = MainViewModel;
            });
            ExpeditionsViewCommand = new RelayCommand((o) =>
            {
                CurrentView = ExpeditionsViewModel;
            });
            CurrentView = MainViewModel;
        }
    }
}
