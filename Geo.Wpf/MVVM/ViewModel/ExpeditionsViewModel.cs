using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Geo.Wpf.Core;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Geo.Wpf.MVVM.ViewModel
{
    public class ExpeditionsViewModel
    {
        private readonly IExpeditionsRepository _expeditionsRepository; 
        public ObservableCollection<Expedition> Expeditions { get; private set; }
        public ICommand Show { get; set; }
        public ExpeditionsViewModel(IExpeditionsRepository expeditionsRepository)
        {
            _expeditionsRepository = expeditionsRepository;
            Expeditions = _expeditionsRepository.GetAll();
            Show = new RelayCommand((o) =>
            {

            });
        }
    }
}
