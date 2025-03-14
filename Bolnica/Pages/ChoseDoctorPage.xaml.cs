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
    /// Interaction logic for ChoseDoctorPage.xaml
    /// </summary>
    public partial class ChoseDoctorPage : Page
    {
        public string Priority { get; set; }

        public ChoseDoctorPage()
        {
            InitializeComponent();
            Priority = "Doctor";
        }

        public ChoseDoctorPage(string date)
        {
            InitializeComponent();
            Priority = "Termin";
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Continue_Handler(object sender, RoutedEventArgs e)
        {
            if (Priority.Equals("Doctor"))
                this.NavigationService.Navigate(new ChoseTerminPage("Doca Docic"));
            else
                this.NavigationService.Navigate(new ConfirmAppointmentPage());
        }
    }
}
