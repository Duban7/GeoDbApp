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
    /// Логика взаимодействия для MapsWindow.xaml
    /// </summary>
    public partial class MapsWindow : Window
    {
        private Map? _savedMap = null;
        public MapsWindow()
        {
            InitializeComponent();
            this.DataContext = new Map();
        }
        public void AddData(ObservableCollection<Region> allRegions)
        {
            this.regionComboBox.ItemsSource = allRegions;
        }
        public void AddData(ObservableCollection<Region> allRegions,
                            Map map)
        {
            _savedMap = new()
            {
                Name = map.Name,
                Type = map.Type,
                Region = map.Region
            };

            this.addButton.Content = "Edit";
            this.DataContext = map;
            this.regionComboBox.ItemsSource = allRegions;
            this.regionComboBox.SelectedItem = map.Region;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
        {

            if (_savedMap != null)
            {
                (this.DataContext as Map)!.Name = _savedMap.Name;
                (this.DataContext as Map)!.Type = _savedMap.Type;
                (this.DataContext as Map)!.Region = _savedMap.Region;
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
            MapValidation();
        }
        private void MapValidation()
        {
            if (
                this.nameTextBox.Text.Length >= 3 &&
                this.typeTextBox.Text.Length >= 3 &&
                this.regionComboBox.SelectedIndex >= 0
               )
                addButton.IsEnabled = true;
            else
                addButton.IsEnabled = false;
        }

        private void regionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (regionComboBox.SelectedIndex >= 0)
                (DataContext as Map)!.Region = (Region)regionComboBox.SelectedItem;
            MapValidation();
        }
    }
}
