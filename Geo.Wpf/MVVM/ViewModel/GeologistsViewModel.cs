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
    public class GeologistsViewModel
    {
        private readonly IGeologistsRepository? _geologistsRepository;
        public ICommand ShowExpeditionsCommand { get; set; }
        public ICommand DeleteGeologistCommand { get; set; }
        public ICommand AddGeologistCommand { get; set; }
        public ICommand EditGeologistCommand { get; set; }
        public ObservableCollection<Geologist>? Geologists { get; set; }
        public GeologistsViewModel(IGeologistsRepository geologistsRepository,
                                   IWindowFactory windowFactory) 
        {
            _geologistsRepository = geologistsRepository;
            Geologists = _geologistsRepository.GetAll();

            ShowExpeditionsCommand = new RelayCommand((o) =>
            {
                List<Expedition> expeditions = (List<Expedition>)o!;
                if (expeditions.Count > 0)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(expeditions.Cast<object>().ToList());
                    viewerWindow.ShowDialog();
                }
                else
                {
                    MessageWindow.Show("There is no expeditions.");
                }
            });

            AddGeologistCommand = new RelayCommand((o) =>
            {
                GeologistWindow geologistWindow = windowFactory.Create<GeologistWindow>()!;
                if (geologistWindow.ShowDialog() == true)
                {
                    Geologist geologist = new()
                    {
                        Name = geologistWindow.nameTextBox.Text,
                        Surname = geologistWindow.surnameTextBox.Text,
                        Patronymic = geologistWindow.patronymicTextBox.Text,
                        State = geologistWindow.stateComboBox.Text
                    };
                    _geologistsRepository.Create(geologist);
                    Geologists.Add(geologist);
                }
            });

            DeleteGeologistCommand = new RelayCommand((o) =>
            {
                if (MessageBoxResult.Yes == MessageWindow.Show("Deleting", "Are you sure want to delete?", MessageBoxButton.YesNo))
                {
                    _geologistsRepository.Remove((Geologist)o!);
                    Geologists.Remove((Geologist)o!);
                }
            });

            EditGeologistCommand = new RelayCommand((o) =>
            {
                Geologist geologist = (Geologist)o!;
                GeologistWindow geologistWindow = windowFactory.Create<GeologistWindow>()!;
                geologistWindow.AddData(geologist);
                if(geologistWindow.ShowDialog()==true)
                {
                    geologist.Name = geologistWindow.nameTextBox.Text;
                    geologist.Surname = geologistWindow.surnameTextBox.Text;
                    geologist.Patronymic = geologistWindow.patronymicTextBox.Text;
                    geologist.State = geologistWindow.stateComboBox.Text;
                    _geologistsRepository.Update(geologist);
                }
            });
        }
    }
}
