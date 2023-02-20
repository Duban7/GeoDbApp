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
        private readonly IGeologistsRepository? _geologistsRepository;
        public ICommand ShowExpeditionsCommand { get; set; }
        public ICommand DeleteGeologistCommand { get; set; }
        public ICommand EditGeologistCommand { get; set; }
        public ObservableCollection<Geologist>? Geologists { get; set; }
        public GeologistsViewModel(IGeologistsRepository geologistsRepository) 
        {
            _geologistsRepository = geologistsRepository;
            Geologists = _geologistsRepository.GetAll();

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
