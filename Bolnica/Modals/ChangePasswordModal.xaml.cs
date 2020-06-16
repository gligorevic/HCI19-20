using Bolnica.State;
using Controller.UserControllers;
using Dto.UserDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Bolnica.Modals
{
    /// <summary>
    /// Interaction logic for ChangePasswordModal.xaml
    /// </summary>
    public partial class ChangePasswordModal : Window, INotifyPropertyChanged
    {
        private UserProfileController userProfileController = new UserProfileController();

        #region INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        public ChangePasswordModal()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Go_Back_Handler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Password_Change_Handler(object sender, RoutedEventArgs e)
        {
            ChangePasswordDTO pdto = new ChangePasswordDTO();
            pdto.userEmail = AppState.GetInstance().CurrentPatient.getEmail();
            pdto.OldPassword = OldPassword;
            pdto.NewPassword = Password;
            Boolean success = userProfileController.ChangePassword(pdto);
            if(!success)
            {
                VisibilityErr1 = Visibility.Visible;
            } else
            {
                this.Close();
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
            if(!ConfPassword.Equals(Password) || ConfPassword.Length == 0)
            {
                VisibilityErr = Visibility.Visible;
                IsEnabledB = false;
            } else
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
