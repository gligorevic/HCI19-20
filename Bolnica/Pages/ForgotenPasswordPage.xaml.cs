﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.Pages
{
    /// <summary>
    /// Interaction logic for ForgotenPasswordPage.xaml
    /// </summary>
    public partial class ForgotenPasswordPage : Page
    {
        public ForgotenPasswordPage()
        {
            InitializeComponent();
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Finsih_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }
    }
}
