using Bolnica.Modals;
using Bolnica.Pages;
using Bolnica.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static readonly RoutedUICommand ChangePassword = new RoutedUICommand("ChangePassword", "ChangePassword", typeof(MainWindow));
        public static readonly RoutedUICommand ViewProfile = new RoutedUICommand("ViewProfile", "ViewProfile", typeof(MainWindow));
        public static readonly RoutedUICommand EditProfile = new RoutedUICommand("EditProfile", "EditProfile", typeof(MainWindow));
        public static readonly RoutedUICommand Home = new RoutedUICommand("Home", "Home", typeof(MainWindow));
        public static readonly RoutedUICommand UpcomingServices = new RoutedUICommand("UpcomingServices", "UpcomingServices", typeof(MainWindow));
        public static readonly RoutedUICommand PassedServices = new RoutedUICommand("PassedServices", "PassedServices", typeof(MainWindow));
        public static readonly RoutedUICommand MedicalRecord = new RoutedUICommand("MedicalRecord", "MedicalRecord", typeof(MainWindow));
        public static readonly RoutedUICommand ScheduleAppointment = new RoutedUICommand("ScheduleAppointment", "ScheduleAppointment", typeof(MainWindow));
        public static readonly RoutedUICommand Blog = new RoutedUICommand("Blog", "Blog", typeof(MainWindow));
        public static readonly RoutedUICommand Help = new RoutedUICommand("Help", "Help", typeof(MainWindow));
        public static readonly RoutedUICommand Logout = new RoutedUICommand("Logout", "Logout", typeof(MainWindow));


        #region NotifyProperties
        private Visibility _logout = Visibility.Collapsed;

        public Visibility LogoutVisibility
        {
            get
            {
                return _logout;
            }
            set
            {
                if (value != _logout)
                {
                    _logout = value;
                    OnPropertyChanged("LogoutVisibility");
                }
            }
        }
 
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        public void setLogoutVisible()
        {
            LogoutVisibility = Visibility.Visible;
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.FontFamily = new FontFamily("Segoe UI");
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

        private void MedicalRecord_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(Frame.NavigationService.Content.GetType().Name.ToString()).Equals("MedicalRecordPage"))
            {
                this.Frame.Navigate(new MedicalRecordPage());
            }
        }

        private void ScheduletAppointment_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(Frame.NavigationService.Content.GetType().Name.ToString()).Equals("ScheduleAppointmentPage"))
            {
                this.Frame.Navigate(new ScheduleAppointmentPage());
            }
        }

        private void Blog_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(Frame.NavigationService.Content.GetType().Name.ToString()).Equals("BlogPage"))
            {
                this.Frame.Navigate(new BlogPage());
            }
        }

        private void Help_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            HelpModal modalWindow = new HelpModal();
            modalWindow.ShowDialog();
        }

        private void Logout_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            LogoutVisibility = Visibility.Collapsed;
            AppState.GetInstance().restart();
            this.Frame.Navigate(new LoginPage());
        }
    }
}
