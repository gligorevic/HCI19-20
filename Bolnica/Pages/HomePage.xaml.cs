using Bolnica.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
           
        }

        private void Show_Profile_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProfilePage());
        }

        private void Show_Services_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ServicesPage());
        }

        private void Schedule_Appointment_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ScheduleAppointmentPage());
        }

        private void Show_MedicalRecord_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MedicalRecordPage());
            
        }
    }
}
