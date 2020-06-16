using Bolnica.State;
using Class_Diagram___Hospital.Dto.MedicalInfoDTOs;
using Class_Diagram___Hospital.Dto.UserDTOs;
using Controller.MedicalInfoControllers;
using Dto.MedicalInfoDTOs;
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
    /// Interaction logic for MedicalRecordPage.xaml
    /// </summary>
    public partial class MedicalRecordPage : Page, INotifyPropertyChanged
    {
        MedicalRecordDTO medicalRecord { get; set; }

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

        private Sex _sex = Sex.Male;

        public Sex Sex
        {
            get { return _sex; }
            set
            {
                if (value != _sex)
                {
                    _sex = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        private string _bloodType;

        public string BloodType
        {
            get
            {
                return _bloodType;
            }
            set
            {
                if (value != _bloodType)
                {
                    _bloodType = value;
                    OnPropertyChanged("BloodType");
                }
            }
        }

        private string _height;

        public string HeightP
        {
            get
            {
                return _height;
            }
            set
            {
                if (value != _height)
                {
                    _height = value;
                    OnPropertyChanged("HeightP");
                }
            }
        }

        private string _weight;

        public string Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value != _weight)
                {
                    _weight = value;
                    OnPropertyChanged("Weight");
                }
            }
        }

        private string _dioptre;

        public string Dioptre
        {
            get
            {
                return _dioptre;
            }
            set
            {
                if (value != _dioptre)
                {
                    _dioptre = value;
                    OnPropertyChanged("Dioptre");
                }
            }
        }

        private List<AllergyDTO> _allergies;

        public List<AllergyDTO> Allergies
        {
            get
            {
                return _allergies;
            }
            set
            {
                if (value != _allergies)
                {
                    _allergies = value;
                    OnPropertyChanged("Allergies");
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

        private MedicalRecordController medicalRecordController = new MedicalRecordController();

        public MedicalRecordPage()
        {
            InitializeComponent();
            this.DataContext = this;
            medicalRecord = medicalRecordController.GetMedicalRecordByPatientId(AppState.GetInstance().CurrentPatient.getId());
            HeightP = medicalRecord.Height == 0 ? "Biće uneto" : medicalRecord.Height.ToString();
            Weight = medicalRecord.Weight == 0 ? "Biće uneto" : medicalRecord.Weight.ToString();
            BloodType = medicalRecord.BloodType == Model.Patient.BloodType.NOT_SETTED ? "Biće uneto" : medicalRecord.BloodType.ToString();
            Dioptre = medicalRecord.Dioptre == -100 ? "Biće uneto" : medicalRecord.Dioptre.ToString();
            Allergies = medicalRecord.Allergies;

            PatientDTO curPatient = AppState.GetInstance().CurrentPatient;
            Sex = curPatient.getSex();
            NameU = curPatient.getName() + " " + curPatient.getLastName();
            DateOfBirth = curPatient.getBirthDate();
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void ViewRecepies_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RecepiesPage());
        }
    }
}
