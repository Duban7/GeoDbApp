using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Geo.Wpf.Windows
{
    /// <summary>
    /// Логика взаимодействия для DataViewerWindow.xaml
    /// </summary>
    public partial class DataViewerWindow : Window
    {
        public DataViewerWindow()
        {
            InitializeComponent();
        }
        
        public void SetData(List<object> items)
        {
            dataGrid.ItemsSource = items;
                
        }
        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //e.Column.Width = DataGridLength.Auto;
            if (e.PropertyType == typeof(DateTime))
            {
                (e.Column as DataGridTextColumn)!.Binding.StringFormat = "dd-MM-yyyy";
            }
            if(e.PropertyType != typeof(string) && e.PropertyType != typeof(Int32) && e.PropertyType != typeof(float))
            {
                e.Cancel = true; 
            }
        }
    }
}
