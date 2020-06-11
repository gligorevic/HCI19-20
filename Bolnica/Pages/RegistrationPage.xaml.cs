using Bolnica.Modals;
using Class_Diagram___Hospital.Controller.LocationControllers;
using Class_Diagram___Hospital.Dto.LocationDTOs;
using Class_Diagram___Hospital.Dto.UserDTOs;
using Controller.UserControllers;
using Model.User;
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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page, INotifyPropertyChanged
    {
        public int ActiveStep { get; set; } = 1;

        private CountryController countryController = new CountryController();
        private CityController cityController = new CityController();

        #region NotifyProperties

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

        private Sex _sex = Sex.Male;

        public Sex Sex
        {
            get { return _sex; }
            set {
                if (value != _sex)
                {
                    _sex = value;
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

        private string _telephone;

        public string Telephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                if (value != _telephone)
                {
                    _telephone = value;
                    OnPropertyChanged("Telephone");
                }
            }
        }

        private DateTime _dateOfBirth = new DateTime();

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value != _dateOfBirth)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
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

        private CityDTO _city;

        public CityDTO City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value != _city)
                {
                    _city = value;
                    OnPropertyChanged("City");
                }
            }
        }

        private List<CityDTO> _cities;

        public List<CityDTO> Cities
        {
            get
            {
                return _cities;
            }
            set
            {
                _cities = value;
                OnPropertyChanged("Cities");
            }

        }

        private CountryDTO _country;

        public CountryDTO Country
        {
            get
            {
                return _country;
            }
            set
            {
                if (value != _country)
                {
                    _country = value;
                    OnPropertyChanged("Country");
                }
            }
        }

        private List<CountryDTO> _countries;

        public List<CountryDTO> Countries
        {
            get
            {
                return _countries;
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

        private string _address;

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        private string _addressNumber;

        public string AddressNumber
        {
            get
            {
                return _addressNumber;
            }
            set
            {
                if (value != _addressNumber)
                {
                    _addressNumber = value;
                    OnPropertyChanged("AddressNumber");
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


        private UnautheticatedUserController unautheticatedUserController = new UnautheticatedUserController();

        public RegistrationPage()
        {
            InitializeComponent();
            this.DataContext = this;

            _countries = countryController.getAllCountries();
            Country = _countries[0];
            _cities = cityController.getCitiesByCountryName(_countries[0].Name);
            City = _cities[0];
        }

        private void IncreaseActive_Step(object sender, RoutedEventArgs e)
        {
            ActiveStep = ActiveStep + 1;
   
            this.stepOneButton.Background = Brushes.White;
            this.stepTwoButton.Background = Brushes.White;
            this.firstStepForm.Visibility = Visibility.Hidden;
            this.secondStepForm.Visibility = Visibility.Hidden;
            switch (ActiveStep)
            {
                case 2:
                    this.secondStepForm.Visibility = Visibility.Visible;
                    this.stepTwoButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");
                    break;
                case 3:
                    this.thirdStepForm.Visibility = Visibility.Visible;
                    this.stepThreeButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");
                    this.ContinueButton.Visibility = Visibility.Hidden;
                    this.RegistrateButton.Visibility = Visibility.Visible;
                    break;
                case 4:
                    PatientDTO patientDTO = new PatientDTO(Sex, DateOfBirth, City, NameU, LastName, Jmbg, Password, Email, Telephone, Address, Int32.Parse(AddressNumber));
                    PatientDTO returnedPatient = unautheticatedUserController.Registration(patientDTO);
                    if (returnedPatient != null)
                    {
                        this.NavigationService.Navigate(new LoginPage());
                        FeedbackModal feedback = new FeedbackModal("Uspešno izvršena registracija", "Uspešna registracija", "Izvršili ste uspešnu registraciju, možete se ulogovati sa emailom " + patientDTO.getEmail() + " i unetom lozinkom i koristiti funkcionalnosti koje nudi aplikacija.", true);
                        feedback.ShowDialog();
                    } else
                    {
                        ActiveStep = 3;
                        FeedbackModal feedback = new FeedbackModal("Neuspešna registracija", "Korisnik već postoji", "Korisnik sa unetim emailom ili jmbg-om već postoji u sistemu. Pokušajte sa unosom drugog emaila.", false);
                        feedback.ShowDialog();
                    }
                    break;
            }
        }

        private void DecreaseActive_Step(object sender, RoutedEventArgs e)
        {
            ActiveStep = ActiveStep - 1;


            this.ContinueButton.Visibility = Visibility.Visible;
            this.RegistrateButton.Visibility = Visibility.Hidden;
            this.stepTwoButton.Background = Brushes.White;
            this.stepThreeButton.Background = Brushes.White;
            this.secondStepForm.Visibility = Visibility.Hidden;
            this.thirdStepForm.Visibility = Visibility.Hidden;
            switch (ActiveStep)
            {
                case 0:
                    this.NavigationService.GoBack();
                    break;
                case 1:
                    this.firstStepForm.Visibility = Visibility.Visible;
                    this.stepOneButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");
                    break;
                case 2:
                    this.secondStepForm.Visibility = Visibility.Visible;
                    this.stepTwoButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");
                    break;
            }
        }

        private void GoOn_Step1_Handler(object sender, RoutedEventArgs e)
        {
            ActiveStep = 1;
            this.stepTwoButton.Background = Brushes.White;
            this.stepThreeButton.Background = Brushes.White;
            this.stepOneButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");

            this.secondStepForm.Visibility = Visibility.Hidden;
            this.thirdStepForm.Visibility = Visibility.Hidden;
            this.firstStepForm.Visibility = Visibility.Visible;
        }

        private void GoOn_Step2_Handler(object sender, RoutedEventArgs e)
        {
            ActiveStep = 2;
            this.stepOneButton.Background = Brushes.White;
            this.stepThreeButton.Background = Brushes.White;
            this.stepTwoButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");

            this.thirdStepForm.Visibility = Visibility.Hidden;
            this.firstStepForm.Visibility = Visibility.Hidden;
            this.secondStepForm.Visibility = Visibility.Visible;  
        }

        private void GoOn_Step3_Handler(object sender, RoutedEventArgs e)
        {
            ActiveStep = 3;
            this.stepOneButton.Background = Brushes.White;
            this.stepTwoButton.Background = Brushes.White;
            this.stepThreeButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");

            this.firstStepForm.Visibility = Visibility.Hidden;
            this.secondStepForm.Visibility = Visibility.Hidden;
            this.thirdStepForm.Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cities = cityController.getCitiesByCountryName(Country.Name);
            City = _cities[0];
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
