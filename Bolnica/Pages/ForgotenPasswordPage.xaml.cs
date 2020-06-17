using Bolnica.Modals;
using Controller.UserControllers;
using Dto.UserDTOs;
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

namespace Bolnica.Pages
{
    /// <summary>
    /// Interaction logic for ForgotenPasswordPage.xaml
    /// </summary>
    public partial class ForgotenPasswordPage : Page, INotifyPropertyChanged
    {
        private UserProfileController userProfileController = new UserProfileController();

        #region NotifyProperties
        private Visibility _visibilityErr = Visibility.Hidden;

        public Visibility VisibilityErr
        {
            get
            {
                return _visibilityErr;
            }
            set
            {
                if (value != _visibilityErr)
                {
                    _visibilityErr = value;
                    OnPropertyChanged("VisibilityErr");
                }
            }
        }

        private string _email;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                VisibilityErr1 = Visibility.Hidden;
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private string _password = "";

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        private string _oldpassword = "";

        public string OldPassword
        {
            get
            {
                return _oldpassword;
            }
            set
            {
                if (value != _oldpassword)
                {
                    _oldpassword = value;
                    OnPropertyChanged("OldPassword");
                }
            }
        }

        private string _confpassword = "";

        public string ConfPassword
        {
            get
            {
                return _confpassword;
            }
            set
            {
                if (value != _confpassword)
                {
                    _confpassword = value;
                    OnPropertyChanged("ConfPassword");
                }
            }
        }

        private Visibility _visibilityErr1 = Visibility.Hidden;

        public Visibility VisibilityErr1
        {
            get
            {
                return _visibilityErr1;
            }
            set
            {
                if (value != _visibilityErr1)
                {
                    _visibilityErr1 = value;
                    OnPropertyChanged("VisibilityErr1");
                }
            }
        }

        private Boolean _isEnabled = false;
        public Boolean IsEnabledB
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    OnPropertyChanged("IsEnabledB");
                }
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public ForgotenPasswordPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Finsih_Handler(object sender, RoutedEventArgs e)
        {
            ChangePasswordDTO pdto = new ChangePasswordDTO();
            pdto.userEmail = Email;
            pdto.OldPassword = OldPassword;
            pdto.NewPassword = Password;
            Boolean success = userProfileController.ChangePassword(pdto);
            if (!success)
            {
                VisibilityErr1 = Visibility.Visible;
            }
            else
            {
                this.NavigationService.Navigate(new LoginPage());
                FeedbackModal feedback = new FeedbackModal("Uspešno promenjena lozinka", "Promenjena lozinka", "Izvršili ste uspešnu promenu lozinke.", true);
                feedback.ShowDialog();
            }

        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }

            if (!ConfPassword.Equals(Password) || ConfPassword.Length == 0)
            {
                VisibilityErr = Visibility.Visible;
                IsEnabledB = false;
            }
            else
            {
                VisibilityErr = Visibility.Hidden;
                IsEnabledB = true;
            }
        }

        private void ConfirmedPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).ConfPassword = ((PasswordBox)sender).Password; }
            if (!ConfPassword.Equals(Password) || ConfPassword.Length == 0)
            {
                VisibilityErr = Visibility.Visible;
                IsEnabledB = false;
            }
            else
            {
                VisibilityErr = Visibility.Hidden;
                IsEnabledB = true;
            }
        }

        private void OldPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            VisibilityErr1 = Visibility.Hidden;
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).OldPassword = ((PasswordBox)sender).Password; }
        }
    }
}
