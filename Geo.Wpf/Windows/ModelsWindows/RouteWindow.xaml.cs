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

namespace Geo.Wpf.Windows.ModelsWindows
{
    /// <summary>
    /// Логика взаимодействия для RouteWindow.xaml
    /// </summary>
    public partial class RouteWindow : Window
    {
        private Route? _savedRoute = null;
        public RouteWindow()
        {
            InitializeComponent();
            this.DataContext = new Route()
            {
                Regions = new ObservableCollection<Region>(),
                Maps = new ObservableCollection<Map>()
            };
        }
        public void AddData (ObservableCollection<Region> allRegions)
        {
            this.regionsComboBox.ItemsSource = allRegions;
            this.mapsComboBox.ItemsSource = new ObservableCollection<Map>();
        }  

        public void AddData(Route route, ObservableCollection<Region> allRegions)
        {
            _savedRoute = new()
            {
                Name = route.Name,
                StartPoint = route.StartPoint,
                EndPoint = route.EndPoint,
                Length = route.Length,
                Regions = new ObservableCollection<Region>(route.Regions),
                Maps = new ObservableCollection<Map>(route.Maps)
            };

            this.addButton.Content = "Edit";
            this.DataContext = route;
            this.regionsComboBox.ItemsSource = allRegions;
            this.mapsComboBox.ItemsSource= new ObservableCollection<Map>();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
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
            RouteValidation();
        }

        private void RegionsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(regionsComboBox.SelectedIndex >= 0)
            {
                Region selectedRegion = (Region)regionsComboBox.SelectedItem;
                (regionsComboBox.ItemsSource as ObservableCollection<Region>)?.Remove(selectedRegion);
                (this.DataContext as Route)?.Regions.Add(selectedRegion);
                regionsComboBox.Items.Refresh();

                foreach(Map map in selectedRegion.Maps)
                    (this.DataContext as Route)?.Maps.Add(map);

                RouteValidation();
            }
        }

        private void RegionsCross_Click(object sender, RoutedEventArgs e)
        {
            Region removedRegion = ((sender as Button)?.Tag as Region)!;
            if (removedRegion != null)
            {
                foreach (Map removedMap in removedRegion.Maps)
                {
                    if ((this.DataContext as Route)!.Maps.Contains<Map>(removedMap))
                        (this.DataContext as Route)?.Maps.Remove(removedMap);
                    if ((mapsComboBox.ItemsSource as ObservableCollection<Map>)!.Contains<Map>(removedMap))
                        (mapsComboBox.ItemsSource as ObservableCollection<Map>)?.Remove(removedMap);
                }
                mapsComboBox.Items.Refresh();

                (regionsComboBox.ItemsSource as ObservableCollection<Region>)?.Add(removedRegion);
                (this.DataContext as Route)?.Regions.Remove(removedRegion);
                regionsComboBox.Items.Refresh();
                RouteValidation();
            }

        }

        private void MapsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(mapsComboBox.SelectedIndex >= 0)
            {
                Map selectedMap = (Map)mapsComboBox.SelectedItem;
                (mapsComboBox.ItemsSource as ObservableCollection<Map>)?.Remove(selectedMap);
                (this.DataContext as Route)?.Maps.Add(selectedMap);
                mapsComboBox.Items.Refresh();

                RouteValidation();
            }
        }
        
        private void MapsCross_Click(object sender, RoutedEventArgs e)
        {
            Map removedMap = ((sender as Button)?.Tag as Map)!;
            if (removedMap != null)
            {
                (mapsComboBox.ItemsSource as ObservableCollection<Map>)?.Add(removedMap);
                (this.DataContext as Route)?.Maps.Remove(removedMap);
                mapsComboBox.Items.Refresh();

                RouteValidation();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void RouteValidation()
        {
            if ((this.DataContext as Route)!.Maps.Count > 0 &&
                (this.DataContext as Route)!.Regions.Count > 0 &&
                nameTextBox.Text.Length >= 3 &&
                StartPointTextBox.Text.Length > 0 &&
                EndPointTextBox.Text.Length > 0 &&
                LengthTextBox.Text.Length > 0 
                ) 
                addButton.IsEnabled = true;
            else
                addButton.IsEnabled = false;
        }

        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            if(_savedRoute != null)
            {
                (this.DataContext as Route)!.Name = _savedRoute.Name;
                (this.DataContext as Route)!.StartPoint = _savedRoute.StartPoint;
                (this.DataContext as Route)!.EndPoint = _savedRoute.EndPoint;
                (this.DataContext as Route)!.Length = _savedRoute.Length;
                (this.DataContext as Route)!.Regions = _savedRoute.Regions;
                (this.DataContext as Route)!.Maps = _savedRoute.Maps;
            }
            this.DialogResult = false;
        }
    }
}
