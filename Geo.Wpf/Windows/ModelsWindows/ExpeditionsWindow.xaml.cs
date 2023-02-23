﻿using Geo.Domain.Models;
using System;
using System.Collections.Generic;
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
        public ExpeditionWindow()
        {
            InitializeComponent();
            this.DataContext = new Expedition();
        }

        public void AddData(Expedition expedition,
                            List<Route> allRoutes,
                            List<Geologist> allGeologists)
        {
            this.DataContext = expedition;
            this.routeComboBox.ItemsSource = allRoutes;
            this.geologistsComboBox.ItemsSource=allGeologists.Except(expedition.Geologists);
        }
        public void AddData(List<Route> allRoutes,
                            List<Geologist> allGeologists)
        {
            this.routeComboBox.ItemsSource = allRoutes;
            this.geologistsComboBox.ItemsSource = allGeologists;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
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
        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if(nameTextBox.Text.Length > 3 && surnameTextBox.Text.Length > 3 && patronymicTextBox.Text.Length > 3)
            {
                addButton.IsEnabled = true;
            }
            //else
            {
                addButton.IsEnabled = false;
            }
        }
    }
}
