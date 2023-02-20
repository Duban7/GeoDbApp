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
    public class GeologistsViewModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IGeologistsRepository? _geologistsRepository;
        public ICommand ShowExpeditionsCommand { get; set; }
        public ICommand DeleteGeologistCommand { get; set; }
        public ICommand EditGeologistCommand { get; set; }
        public ObservableCollection<Geologist>? Geologists { get; set; }
        public GeologistsViewModel(IServiceProvider serviceProvider, IGeologistsRepository geologistsRepository) 
        {
            _serviceProvider = serviceProvider;
            _geologistsRepository = geologistsRepository;
            Geologists = geologistsRepository.GetAll();

            ShowExpeditionsCommand = new RelayCommand((o)=>
            {
                MessageBox.Show(((List<Expedition>?)o)?.Count.ToString());
            });

            DeleteGeologistCommand = new RelayCommand((o) =>
            {
                MessageBox.Show("Delete");
            });

            EditGeologistCommand = new RelayCommand((o) =>
            {
                MessageBox.Show("Edit");
            });
        }
    }
}
