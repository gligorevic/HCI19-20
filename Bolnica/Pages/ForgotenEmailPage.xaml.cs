using Bolnica.Modals;
using Class_Diagram___Hospital.Controller.Abstract;
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
    /// Interaction logic for ForgotenEmailPage.xaml
    /// </summary>
    public partial class ForgotenEmailPage : Page, INotifyPropertyChanged
    {
        private readonly IUnatuhenticatedUserController _unautheticatedUserController; 

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


        private string _name;

        public string NameU
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("NameU");
                }
            }
        }

        private string _lastName;

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
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

        private string _jmbg;

        public string Jmbg
        {
            get
            {
                return _jmbg;
            }
            set
            {
                if (value != _jmbg)
                {
                    _jmbg = value;
                    OnPropertyChanged("Jmbg");
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



        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public ForgotenEmailPage()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _unautheticatedUserController = app.UnatuhenticatedUserController;
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Finsih_Handler(object sender, RoutedEventArgs e)
        {
            ChangeEmailDTO changeEmail = new ChangeEmailDTO(NameU, LastName, Jmbg, Email, Password);
            Boolean success = _unautheticatedUserController.ChangeEmail(changeEmail);
            if (success)
            {
                this.NavigationService.Navigate(new LoginPage());
                FeedbackModal modalWindow = new FeedbackModal("Usepsno promenjen email", "Promenjen email", "Uspesno ste promenili email, od sada se prijavljujete koristeci novi email.", true);
                modalWindow.ShowDialog();

            } else
            {
                VisibilityErr = Visibility.Visible;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
