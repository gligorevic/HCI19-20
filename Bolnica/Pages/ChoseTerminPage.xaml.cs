using Bolnica.State;
using Class_Diagram___Hospital.Controller.DoctorControllers.Abstract;
using Class_Diagram___Hospital.Controller.MedicalServiceControllers.Abstract;
using Controller.DoctorControllers;
using Controller.MedicalServiceControllers;
using Dto.MedicalServiceDTOs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.Pages
{
    /// <summary>
    /// Interaction logic for ChoseTerminPage.xaml
    /// </summary>
    public partial class ChoseTerminPage : Page, INotifyPropertyChanged
    {
        private int counterSelectionDate { get; set; } = 0;

        private IDoctorsController _doctorController;
        private IAppointmentController _appointmentController;
        private DoctorDTO PickedDoctor { get; set; }
        private List<DateTime> availableDates;
        private DateTime SelectedDate { get; set; }
        private AppointmentOperationDTO Appointment { get; set; }

        public string Priority { get; set; }

        #region INotifyPropertyChanged
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

        private TimeSpan _pickedTime;

        public TimeSpan PickedTime
        {
            get
            {
                return _pickedTime;
            }
            set
            {
                if (value != _pickedTime)
                {
                    _pickedTime = value;
                    OnPropertyChanged("PickedTime");
                }
            }
        }

        private List<TimeSpan> _timesList;

        public List<TimeSpan> TimesList
        {
            get
            {
                return _timesList;
            }
            set
            {
                if (value != _timesList)
                {
                    _timesList = value;
                    OnPropertyChanged("TimesList");
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

        public ChoseTerminPage(AppointmentOperationDTO appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _doctorController = app.DoctorController;
            _appointmentController = app.AppointmentController;

            Appointment = appointment;

            availableDates = _doctorController.GetAllAvailableAppointmentDates();
            Priority = "Postpone";

            foreach (DateTime date in availableDates)
            {
                MonthlyCalendar.SelectedDates.Add(date);
            }
        }

        public ChoseTerminPage(DoctorDTO doctor)
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _doctorController = app.DoctorController;
            _appointmentController = app.AppointmentController;

            Priority = "Doctor";
            PickedDoctor = doctor;

            availableDates = _doctorController.GetAllAvailableAppointmentDatesByDocotrId(doctor.Id);
            foreach (DateTime date in availableDates)
            {
                MonthlyCalendar.SelectedDates.Add(date);
            }
        }

        public ChoseTerminPage()
        {
            InitializeComponent();
            Priority = "Termin";
            this.DataContext = this;

            var app = Application.Current as App;
            _doctorController = app.DoctorController;
            _appointmentController = app.AppointmentController;


            availableDates = _doctorController.GetAllAvailableAppointmentDates();
            
            foreach (DateTime date in availableDates)
            {
                MonthlyCalendar.SelectedDates.Add(date);
            }
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            if (Priority == "Doctor")
                this.NavigationService.Navigate(new ChoseDoctorPage());
            else if (Priority.Equals("Termin"))
                this.NavigationService.Navigate(new ScheduleAppointmentPage());
            else
                this.NavigationService.Navigate(new UpcomingServicesPage());
        }

        private void Continue_Handler(object sender, RoutedEventArgs e)
        {
            if (Priority.Equals("Doctor"))
                this.NavigationService.Navigate(new ConfirmAppointmentPage(PickedDoctor, PickedTime, SelectedDate, Priority));
            else if (Priority.Equals("Termin"))
                this.NavigationService.Navigate(new ChoseDoctorPage(PickedTime, SelectedDate));
            else
            {
                Appointment.StartDate = SelectedDate.Date + PickedTime;
                this.NavigationService.Navigate(new ChoseDoctorPage(Appointment));
            }
        }

        private void Calendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(counterSelectionDate);
            if (MonthlyCalendar.SelectedDate != null)
            {
                if (counterSelectionDate >= availableDates.Count)
                {
                    SelectedDate = MonthlyCalendar.SelectedDate.Value;
                    
                    if(Priority.Equals("Doctor"))
                    {
                        TimesList = _appointmentController.GetAvailableAppointmentTimesByDateAndPatientAndDoctorId(SelectedDate, AppState.GetInstance().CurrentPatient.GetId(), PickedDoctor.Id);
                        
                        if(TimesList != null && TimesList.Count > 0)
                        {
                            PickedTime = TimesList[0];
                            IsEnabledButton = true;
                        } else
                        {
                            IsEnabledButton = false;
                        }
                    } else 
                    {
                        TimesList = _appointmentController.GetAvailableAppointmentTimesByDateAndPatientId(SelectedDate, AppState.GetInstance().CurrentPatient.GetId());

                        if (TimesList != null && TimesList.Count > 0)
                        {
                            PickedTime = TimesList[0];
                            IsEnabledButton = true;
                        } else
                        {
                            IsEnabledButton = false;
                        }
                    }

                    counterSelectionDate = 0;
                }
            }

            counterSelectionDate = counterSelectionDate + 1;

            foreach (DateTime date in availableDates)
            {
                MonthlyCalendar.SelectedDates.Add(date);
            }
            
        }
    }

    
}
