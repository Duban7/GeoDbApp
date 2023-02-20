using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Geo.Wpf.Core;
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
        public ExpeditionsViewModel(IExpeditionsRepository expeditionsRepository)
        {
            _expeditionsRepository = expeditionsRepository;
            Expeditions = _expeditionsRepository.GetAll();
            ShowGeologistsCommand = new RelayCommand((o) =>
            {
                StringBuilder stringBuilder = new(); 
                foreach (Geologist g in (List<Geologist>?)o!)
                {
                    if (g != null)
                    {
                        stringBuilder.Append(g.Name);
                        stringBuilder.Append(' ');
                        stringBuilder.Append(g.Surname);
                        stringBuilder.Append('\n');
                    }
                }
                MessageBox.Show(stringBuilder.ToString());
                
            });

            ShowRouteCommand = new RelayCommand((o) =>
            {
                Route? route = (Route)o!;
                if (route != null)
                {
                    MessageBox.Show(route.Name);
                }
            });
        }
    }
}
