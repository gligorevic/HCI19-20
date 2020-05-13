using Bolnica.Modals;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window
    {
        public static readonly RoutedUICommand ChangePassword = new RoutedUICommand("ChangePassword", "ChangePassword", typeof(MainWindow));
        public static readonly RoutedUICommand ViewProfile = new RoutedUICommand("ViewProfile", "ViewProfile", typeof(MainWindow));
        public static readonly RoutedUICommand EditProfile = new RoutedUICommand("EditProfile", "EditProfile", typeof(MainWindow));
        public static readonly RoutedUICommand Home = new RoutedUICommand("Home", "Home", typeof(MainWindow));
        public static readonly RoutedUICommand UpcomingServices = new RoutedUICommand("UpcomingServices", "UpcomingServices", typeof(MainWindow));
        public static readonly RoutedUICommand PassedServices = new RoutedUICommand("PassedServices", "PassedServices", typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangePassword_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            ChangePasswordModal modalWindow = new ChangePasswordModal();
            modalWindow.ShowDialog();
        }

        private void ViewProfile_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(Frame.NavigationService.Content.GetType().Name.ToString()).Equals("ProfilePage"))
            {
                this.Frame.Navigate(new ProfilePage());
            }
        }

        private void EditProfile_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(Frame.NavigationService.Content.GetType().Name.ToString()).Equals("EditProfilePage"))
            {
                this.Frame.Navigate(new EditProfilePage());
            }
        }

        private void GoHome_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(Frame.NavigationService.Content.GetType().Name.ToString()).Equals("HomePage"))
            {
                this.Frame.Navigate(new HomePage());
            }
        }

        private void UpcomingServices_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(Frame.NavigationService.Content.GetType().Name.ToString()).Equals("UpcomingServicesPage"))
            {
                this.Frame.Navigate(new UpcomingServicesPage());
            }
        }

        private void PassedServices_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(Frame.NavigationService.Content.GetType().Name.ToString()).Equals("PassedServicesPage"))
            {
                this.Frame.Navigate(new PassedServicesPage());
            }
        }
    }
}
