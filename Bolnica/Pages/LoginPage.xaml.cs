using Bolnica.Modals;
using Bolnica.State;
using Class_Diagram___Hospital.Dto.UserDTOs;
using Controller.PatientControllers;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page, INotifyPropertyChanged
    {
        private UnautheticatedUserController unautheticatedUserController = new UnautheticatedUserController();
        private AppState state = AppState.GetInstance();
        private PatientController patientController = new PatientController();

        #region NotifyProperties
        private string _nameAndLastName;

        public string NameAndLastName
        {
            get
            {
                return _nameAndLastName;
            }
            set
            {
                if (value != _nameAndLastName)
                {
                    _nameAndLastName = value;
                    OnPropertyChanged("NameAndLastName");
                }
            }
        }

        private string _foundEmail;

        public string FoundEmail
        {
            get
            {
                return _foundEmail;
            }
            set
            {
                if (value != _foundEmail)
                {
                    _foundEmail = value;
                    OnPropertyChanged("FoundEmail");
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
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private string _password;

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

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        public int ActiveStep { get; set; } = 1;

        public LoginPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            ActiveStep = ActiveStep - 1;
            this.ContinueButton.Content = "Nastavi";
            this.ContinueButton.ToolTip = "Nastavi na unos lozinke";
            switch (ActiveStep)
            {
                case 0:
                    this.NavigationService.GoBack();
                    break;
                case 1:
                    this.forgotenButton.Text = "Zaboravljen mail?";
                    this.firstStep.Visibility = Visibility.Visible;
                    this.secondStep.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void GoToNextStep_Handler(object sender, RoutedEventArgs e)
        {
            if(ActiveStep == 1)
            {
                UserInfoDTO foundUser = unautheticatedUserController.GetUserInfoByEmail(Email);
                if(foundUser == null)
                {
                    FeedbackModal f = new FeedbackModal("Korisnik nije pronađen", "Greška, korisnik ne postoji", "Korisnik sa unetom email adresom ne postoji, pokusajte sa ponovnim unosom vodeci racuna o velikim i malim slovima.", false);
                    f.ShowDialog();
                    return;
                } 

                FoundEmail = foundUser.getEmail();
                NameAndLastName = foundUser.getName() + " " + foundUser.getLastName();

                ActiveStep = ActiveStep + 1;
                this.ContinueButton.Content = "Uloguj se";
                this.ContinueButton.ToolTip = "Prijavi se na svoj nalog";
                this.forgotenButton.Text = "Zaboravljena lozinka?";
                this.firstStep.Visibility = Visibility.Hidden;
                this.secondStep.Visibility = Visibility.Visible;
            }
            else if (ActiveStep == 2)
            {
                UserDTO user = unautheticatedUserController.Login(Email, Password);
                PatientDTO patient = patientController.GetPatientByUserId(user.getId());
                if(user != null)
                {
                    state.CurrentUser = user;
                    state.CurrentPatient = patient;
                    this.NavigationService.Navigate(new HomePage());
                } else
                {
                    FeedbackModal f = new FeedbackModal("Pogrešna lozinka", "Greška, lozinka se ne poklapa", "Korisnik sa unetom email adresom ne koristi unetu lozinku, pokusajte sa ponovnim unosom vodeci racuna o velikim i malim slovima.", false);
                    f.ShowDialog();
                    return;
                }  
            }
            
        }

        private void Forgoten_Handler(object sender, MouseButtonEventArgs e)
        {
            switch (ActiveStep)
            {
                case 1:
                    this.NavigationService.Navigate(new ForgotenEmailPage());
                    break;

                case 2:
                    this.NavigationService.Navigate(new ForgotenPasswordPage());
                    break;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
