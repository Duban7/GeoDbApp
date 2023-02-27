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
    /// Логика взаимодействия для RegionWindow.xaml
    /// </summary>
    public partial class RegionWindow : Window
    {
        private Region? _savedRegion = null;
        public RegionWindow()
        {
            InitializeComponent();
            this.DataContext = new Region()
            { 
                Maps = new ObservableCollection<Map>()
            };
        }

        public void AddData(Region region)
        {
            _savedRegion = new()
            {
                Name = region.Name,
                Country = region.Country,
            };

            this.addButton.Content = "Edit";
            this.DataContext = region;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
        {

            if (_savedRegion != null)
            {
                (this.DataContext as Region)!.Name = _savedRegion.Name;
                (this.DataContext as Region)!.Country = _savedRegion.Country;
            }
            this.DialogResult = false;
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
            RegionValidation();
        }

        private void RegionValidation()
        {
            if (this.nameTextBox.Text.Length >= 3 && this.countryTextBox.Text.Length >= 3)
                addButton.IsEnabled = true;
            else 
                addButton.IsEnabled= false;
        }
    }
}
