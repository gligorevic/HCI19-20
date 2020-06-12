using Bolnica.State;
using Class_Diagram___Hospital.Controller.LocationControllers;
using Class_Diagram___Hospital.Dto.LocationDTOs;
using Class_Diagram___Hospital.Dto.UserDTOs;
using Controller.PatientControllers;
using Dto.UserDTOs;
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
    /// Interaction logic for EditProfilePage.xaml
    /// </summary>
    public partial class EditProfilePage : Page, INotifyPropertyChanged
    {
        private CountryController countryController = new CountryController();
        private CityController cityController = new CityController();
        private AppState state = AppState.GetInstance();

        private PatientController patientController = new PatientController();

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

        private DateTime _dateOfBirth;

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

        private Sex _sex;

        public Sex Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                if (value != _sex)
                {
                    _sex = value;
                    OnPropertyChanged("Sex");
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
            set
            {
                _countries = value;
                OnPropertyChanged("Countries");
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        public EditProfilePage()
        {
            InitializeComponent();
            this.DataContext = this;

            PatientDTO patient = state.CurrentPatient;

            Countries = countryController.getAllCountries();
            Country = Countries.Find(c => c.Name.Equals(patient.getBirthPlace().CountryName));
            

            Cities = cityController.getCitiesByCountryName(patient.getBirthPlace().CountryName);
            City = Cities.Find(c => c.Name.Equals(patient.getBirthPlace().Name));

            NameU = patient.getName();
            LastName = patient.getLastName();
            DateOfBirth = patient.getBirthDate();
            Sex = patient.getSex();
            Address = patient.getAddress();
            AddressNumber = patient.getAppartmentNumber().ToString();
            Telephone = patient.getTelephone();
            Email = patient.getEmail();
            Jmbg = patient.getJmbg();
        }

        private void Go_Back_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void SaveChanges_Handler(object sender, RoutedEventArgs e)
        {
            PatientDTO patientDTO = new PatientDTO(Sex, DateOfBirth, City, NameU, LastName, Jmbg, null, Email, Telephone, Address, Int32.Parse(AddressNumber));
            patientDTO.setId(AppState.GetInstance().CurrentPatient.getId());
            PatientDTO returnedPatient = patientController.editPatient(patientDTO);
            AppState.GetInstance().CurrentPatient = returnedPatient;
            AppState.GetInstance().CurrentUser = returnedPatient;

            if (returnedPatient != null)
                this.NavigationService.Navigate(new ProfilePage());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cities = cityController.getCitiesByCountryName(Country.Name);
            CityDTO curCity = Cities.Find(c => c.Name.Equals(AppState.GetInstance().CurrentPatient.getBirthPlace().Name));
            if (curCity == null) City = _cities[0];
            else City = curCity;
        }
    }
}
