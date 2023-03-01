using Geo.DAL.repositories.Queries;
using Geo.Domain.Models;
using Geo.Wpf.Core;
using Geo.Wpf.WindowFactory.Interfaces;
using Geo.Wpf.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Geo.Wpf.MVVM.ViewModel
{
    public class MainViewModel
    {
        public ICommand FirstQueryCommand { get; set; }
        public ICommand SecondQueryCommand { get; set; }
        public ICommand ThirdQueryCommand { get; set; }
        public ICommand FourthQueryCommand { get; set; }
        public ICommand ProcedureCommand { get; set; }
        public ICommand FunctionCommand { get; set; }
        public MainViewModel(DbQueries dbQueries, IWindowFactory windowFactory)
        {
            FirstQueryCommand = new RelayCommand((o) =>
            {
                var result = dbQueries.FirstQuery();
                if (result!=null)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(result);
                    viewerWindow.ShowDialog();
                }
                else MessageWindow.Show("Query retured nothing.");
            });
            SecondQueryCommand = new RelayCommand((o) =>
            {
                var result = dbQueries.SecondQuery();
                if (result != null)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(result);
                    viewerWindow.ShowDialog();
                }
                else MessageWindow.Show("Query retured nothing.");
            });
            ThirdQueryCommand = new RelayCommand((o) =>
            {
                var result = dbQueries.ThirdQuery();
                if (result != null)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(result);
                    viewerWindow.ShowDialog();
                }
                else MessageWindow.Show("Query retured nothing.");
            });
            FourthQueryCommand = new RelayCommand((o) =>
            {
                var result = dbQueries.FourthQuery();
                if (result != null)
                {
                    DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                    viewerWindow.SetData(result);
                    viewerWindow.ShowDialog();
                }
                else MessageWindow.Show("Query retured nothing.");
            });
            ProcedureCommand = new RelayCommand((o) =>
            {
                string expeditionName = (string)o!;
                if (expeditionName.Length > 0)
                {
                    var result = dbQueries.Procedure(expeditionName);
                    if (result != null)
                    {
                        DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                        viewerWindow.SetData(result);
                        viewerWindow.ShowDialog();
                    }
                    else MessageWindow.Show("Query retured nothing.");
                }
                else MessageWindow.Show("Enter expedition name.");
            });
            FunctionCommand = new RelayCommand((o) =>
            {
                string mapName = (string)o!;
                if (mapName.Length > 0)
                {
                    var result = dbQueries.Function(mapName);
                    if (result != null)
                    {
                        DataViewerWindow viewerWindow = windowFactory.Create<DataViewerWindow>()!;
                        viewerWindow.SetData(result);
                        viewerWindow.ShowDialog();
                    }
                    else MessageWindow.Show("Query retured nothing.");
                }
                else MessageWindow.Show("Enter map name.");
            });
        }  
    }
}
