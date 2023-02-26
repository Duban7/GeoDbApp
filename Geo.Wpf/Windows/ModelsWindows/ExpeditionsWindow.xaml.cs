using Geo.DAL.repositories.implementation;
using Geo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Логика взаимодействия для GeologistWindow.xaml
    /// </summary>
    public partial class ExpeditionWindow : Window
    {
        private Expedition? _savedExpedition = null;
        public ExpeditionWindow()
        {
            InitializeComponent();
            this.DataContext = new Expedition()
            {
                Geologists = new ObservableCollection<Geologist>()
            };
        }

        public void AddData(Expedition expedition,
                            ObservableCollection<Route> allRoutes,
                            ObservableCollection<Geologist> allGeologists)
        {
            _savedExpedition = new()
            {
                Name = expedition.Name,
                Date = expedition.Date,
                Route = expedition.Route,
                Geologists = new ObservableCollection<Geologist>(expedition.Geologists)
            };

            this.addButton.Content = "Edit";
            this.DataContext = expedition;
            this.routeComboBox.ItemsSource = allRoutes;
            this.routeComboBox.SelectedItem = expedition.Route;
            this.geologistsComboBox.ItemsSource = new ObservableCollection<Geologist>(allGeologists.Except(expedition.Geologists));
            MessageBox.Show(allGeologists.Except(expedition.Geologists).Count().ToString());
        }
        public void AddData(ObservableCollection<Route> allRoutes,
                            ObservableCollection<Geologist> allGeologists)
        {
            this.routeComboBox.ItemsSource = allRoutes;
            this.geologistsComboBox.ItemsSource = allGeologists;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
        {

            if (_savedExpedition != null)
            {
                (this.DataContext as Expedition)!.Name = _savedExpedition.Name;
                (this.DataContext as Expedition)!.Date = _savedExpedition.Date;
                (this.DataContext as Expedition)!.Route = _savedExpedition.Route;
                (this.DataContext as Expedition)!.Geologists = _savedExpedition.Geologists;
            }
            this.DialogResult = false;
        }
        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                if (this.WindowState == WindowState.Maximized)
                    this.WindowState = WindowState.Normal;
                this.DragMove();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExpeditionValidation();
        }

        private void Cross_Click(object sender, RoutedEventArgs e)
        {
            Geologist removedGeologist = ((sender as Button)?.Tag as Geologist)!;
            (geologistsComboBox.ItemsSource as ObservableCollection<Geologist>)?.Add(removedGeologist);
            (this.DataContext as Expedition)?.Geologists.Remove(removedGeologist);
            geologistsComboBox.Items.Refresh();
            ExpeditionValidation();
        }

        private void geologistsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (geologistsComboBox.SelectedIndex >= 0) { 
                Geologist selectedGeologist = (Geologist)geologistsComboBox.SelectedItem;
                (geologistsComboBox.ItemsSource as ObservableCollection<Geologist>)?.Remove(selectedGeologist);
                (this.DataContext as Expedition)?.Geologists.Add(selectedGeologist);
                geologistsComboBox.Items.Refresh();
                ExpeditionValidation();
            }
        }

        private void routeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (routeComboBox.SelectedIndex >= 0)
                (DataContext as Expedition)!.Route = (Route)routeComboBox.SelectedItem;
            ExpeditionValidation();
        }

        private void ExpeditionValidation()
        {
            if(
                (this.DataContext as Expedition)?.Geologists.Count > 2 &&
                routeComboBox.SelectedIndex >= 0 &&
                DatePickerTextBox.Text.Length == 10 &&
                nameTextBox.Text.Length >= 5
               ) 
                addButton.IsEnabled = true;
            else 
                addButton.IsEnabled = false;
        }
    }
}
