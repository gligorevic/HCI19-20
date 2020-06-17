using Controller.DoctorControllers;
using Dto.MedicalServiceDTOs;
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
    /// Interaction logic for ChoseDoctorPage.xaml
    /// </summary>
    public partial class ChoseDoctorPage : Page, INotifyPropertyChanged
    {
        private DoctorsController doctorsController = new DoctorsController();
        private TimeSpan PickedTime { get; set; }
        private DateTime PickedDate { get; set; }
        private AppointmentOperationDTO Appointment { get; set; }

        private List<DoctorDTO> allDoctors;
        #region NotifyProperties
        private Boolean _isEnabledButton;

        public Boolean IsEnabledButton
        {
            get
            {
                return _isEnabledButton;
            }
            set
            {
                if (value != _isEnabledButton)
                {
                    _isEnabledButton = value;
                    OnPropertyChanged("IsEnabledButton");
                }
            }
        }

        private string _doctorFilter;

        public string DoctorFilter
        {
            get
            {
                return _doctorFilter;
            }
            set
            {
                if (value != _doctorFilter)
                {
                    _doctorFilter = value;
                    OnPropertyChanged("DoctorFilter");
                }
            }
        }

        private DoctorDTO _doctor;

        public DoctorDTO Doctor
        {
            get
            {
                return _doctor;
            }
            set
            {
                if (value != _doctor)
                {
                    _doctor = value;
                    OnPropertyChanged("Doctor");
                }
            }
        }

        private List<DoctorDTO> _doctors;

        public List<DoctorDTO> Doctors
        {
            get
            {
                return _doctors;
            }
            set
            {
                _doctors = value;
                OnPropertyChanged("Doctors");
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

        public string Priority { get; set; }

        public ChoseDoctorPage(AppointmentOperationDTO appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            Priority = "Postpone";

            Appointment = appointment;

            allDoctors = doctorsController.getDoctorsByDateTime(Appointment.StartDate);
            Doctors = allDoctors;
            if (Doctors != null) Doctor = Doctors[0];

            if (allDoctors != null && allDoctors.Count == 0)
            {
                IsEnabledButton = false;
            }
            else
            {
                IsEnabledButton = true;
            }
        }

        public ChoseDoctorPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Priority = "Doctor";

            allDoctors = doctorsController.GetAllDoctors();
            Doctors = allDoctors;
            if (Doctors != null) Doctor = Doctors[0];

            if (allDoctors != null && allDoctors.Count == 0)
            {
                IsEnabledButton = false;
            }
            else
            {
                IsEnabledButton = true;
            }
        }

        public ChoseDoctorPage(TimeSpan pickedTime, DateTime pickedDate)
        {
            InitializeComponent();
            this.DataContext = this;
            Priority = "Termin";
            PickedTime = pickedTime;
            PickedDate = pickedDate;

            allDoctors = doctorsController.getDoctorsByDateTime(PickedDate.Date + pickedTime);
            
            Doctors = allDoctors;
            if (Doctors != null) Doctor = Doctors[0];

            if(allDoctors != null && allDoctors.Count == 0)
            {
                IsEnabledButton = false;
            } else
            {
                IsEnabledButton = true;
            }
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            if (Priority.Equals("Doctor"))
                this.NavigationService.Navigate(new ScheduleAppointmentPage());
            else if (Priority.Equals("Termin"))
                this.NavigationService.Navigate(new ChoseTerminPage());
            else
                this.NavigationService.Navigate(new ChoseTerminPage(Appointment));
        }

        private void Continue_Handler(object sender, RoutedEventArgs e)
        {
            if (Priority.Equals("Doctor"))
                this.NavigationService.Navigate(new ChoseTerminPage(Doctor));
            else if (Priority.Equals("Termin"))
                this.NavigationService.Navigate(new ConfirmAppointmentPage(Doctor, PickedTime, PickedDate, Priority));
            else
            {
                Appointment.DoctorId = Doctor.id;
                Appointment.DoctorName = Doctor.Name + " " + Doctor.LastName;
                this.NavigationService.Navigate(new ConfirmAppointmentPage(Appointment));
            }
        }

        private void Number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbSelect.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "1+":
                    Doctors = allDoctors;
                    break;
                case "2+":
                    Doctors = allDoctors.Where(d => d.AverageRate == 0 || d.AverageRate >= 2).ToList();
                    break;
                case "3+":
                    Doctors = allDoctors.Where(d => d.AverageRate == 0 || d.AverageRate >= 3).ToList();
                    break;
                case "4+":
                    Doctors = allDoctors.Where(d => d.AverageRate == 0 || d.AverageRate >= 4).ToList();
                    break;
                case "5":
                    Doctors = allDoctors.Where(d => d.AverageRate == 0 || d.AverageRate == 5).ToList();
                    break;
            }

        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            Doctors = allDoctors.Where(d => String.Concat(d.Name.ToLower(), " ", d.LastName.ToLower()).Contains(DoctorFilter.ToLower())).ToList();
        }
    }
}
