using Bolnica.State;
using Controller.DoctorControllers;
using Controller.MedicalServiceControllers;
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

        private DoctorsController doctorController = new DoctorsController();
        private AppointmentController appointmentController = new AppointmentController();
        private DoctorDTO PickedDoctor { get; set; }
        private List<DateTime> availableDates;
        DateTime SelectedDate { get; set; }

        public string Priority { get; set; }

        #region INotifyPropertyChanged
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

        public ChoseTerminPage(DoctorDTO doctor)
        {
            InitializeComponent();
            this.DataContext = this;
            Priority = "Doctor";
            PickedDoctor = doctor;

            availableDates = doctorController.GetAllAvailableAppointmentDatesByDocotrId(doctor.id);
            foreach (DateTime date in availableDates)
            {
                MonthlyCalendar.SelectedDates.Add(date);
            }
        }

        public ChoseTerminPage()
        {
            InitializeComponent();
            Priority = "Termin";
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Continue_Handler(object sender, RoutedEventArgs e)
        {
            if (Priority.Equals("Doctor"))
                this.NavigationService.Navigate(new ConfirmAppointmentPage(PickedDoctor, PickedTime, SelectedDate, Priority));
            else
                this.NavigationService.Navigate(new ChoseDoctorPage("21.10.2020. 12:44"));
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
                        TimesList = appointmentController.GetAvailableAppointmentTimesByDateAndPatientAndDoctorId(SelectedDate, AppState.GetInstance().CurrentPatient.getId(), PickedDoctor.id);
                        
                        if(TimesList != null && TimesList.Count > 0)
                            PickedTime = TimesList[0];
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
