using Bolnica.Modals;
using Bolnica.State;
using Controller.EquipmentAndRoomsController;
using Controller.PatientControllers;
using Dto.MedicalServiceDTOs;
using Dto.UserDTOs;
using Model.EquipmentAndRooms;
using Model.MedicalService;
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
    /// Interaction logic for ConfirmAppointmentPage.xaml
    /// </summary>
    public partial class ConfirmAppointmentPage : Page, INotifyPropertyChanged
    {
        private DoctorDTO PickedDoctor { get; set; }
        private ServiceRoomController serviceRoomController = new ServiceRoomController();
        private PatientController patientController = new PatientController();

        private ServiceRoom serviceRoom { get; set; }
        private AppointmentOperationDTO Appointment { get; set; }

        #region INotifyPropertyChanged
        private Priority _priority;

        public Priority Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                if (value != _priority)
                {
                    _priority = value;
                    OnPropertyChanged("Priority");
                }
            }
        }


        private DateTime _pickedDateTime;

        public DateTime PickedDateTime
        {
            get
            {
                return _pickedDateTime;
            }
            set
            {
                if (value != _pickedDateTime)
                {
                    _pickedDateTime = value;
                    OnPropertyChanged("PickedDateTime");
                }
            }
        }

        private string _serviceRoom;

        public string AvailableServiceRoom
        {
            get
            {
                return _serviceRoom;
            }
            set
            {
                if (value != _serviceRoom)
                {
                    _serviceRoom = value;
                    OnPropertyChanged("AvailableServiceRoom");
                }
            }
        }

        private string _doctorName;

        public string DoctorName
        {
            get
            {
                return _doctorName;
            }
            set
            {
                if (value != _doctorName)
                {
                    _doctorName = value;
                    OnPropertyChanged("DoctorName");
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
        public ConfirmAppointmentPage(AppointmentOperationDTO appointment)
        {
            InitializeComponent();
            this.DataContext = this;

            Appointment = appointment;

            DoctorName = "dr. " + appointment.DoctorName;
            PickedDateTime = appointment.StartDate;
            serviceRoom = serviceRoomController.getAvailableServiceRoom(appointment.StartDate);
            if (serviceRoom == null)
            {
                AvailableServiceRoom = "Soba ce biti naknadno dodeljena.";
            }
            else
            {
                AvailableServiceRoom = serviceRoom.getRoomName();
            }
            Priority = Priority.Date;
        }


        public ConfirmAppointmentPage(Dto.UserDTOs.DoctorDTO pickedDoctor, TimeSpan pickedTime, DateTime selectedDate, string priority)
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorName = "dr. " + pickedDoctor.Name + " " + pickedDoctor.LastName;
            PickedDoctor = pickedDoctor;
            PickedDateTime = selectedDate.Date + pickedTime;
            serviceRoom = serviceRoomController.getAvailableServiceRoom(selectedDate.Date + pickedTime);
            if (serviceRoom == null)
            {
                AvailableServiceRoom = "Soba ce biti naknadno dodeljena.";
            }
            else
            {
                AvailableServiceRoom = serviceRoom.getRoomName();
            }

            if (priority.Equals("Doctor"))
            {
                Priority = Priority.Doctor;
            }
            else
            {
                Priority = Priority.Date;
            }
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void ScheduleAppointment_Handler(object sender, RoutedEventArgs e)
        {
            if (Appointment == null)
            {
                AppointmentOperationDTO appointmentOperationDTO;
                if (serviceRoom != null)
                {  
                    appointmentOperationDTO = new AppointmentOperationDTO(PickedDoctor.id, AppState.GetInstance().CurrentPatient.getId(), serviceRoom.getId(), Priority, PickedDateTime);
                }
                else {
                    appointmentOperationDTO = new AppointmentOperationDTO(PickedDoctor.id, AppState.GetInstance().CurrentPatient.getId(), -1, Priority, PickedDateTime);
                }
                AppointmentOperationDTO appointment = patientController.scheduleAppointment(appointmentOperationDTO);
                if (appointment != null)
                {
                    this.NavigationService.Navigate(new HomePage());
                    FeedbackModal feedback = new FeedbackModal("Usepešno zakazan pregled", "Uspešno zakazan pregled", "Izvšili ste uspešno zakazivanje pregleda za " + appointment.getStartDate() + " kod doktora " + PickedDoctor.Name + " " + PickedDoctor.LastName + ". Proverite salu na dan izvršavanja pregleda, jer može doći do promene.", true);
                    feedback.ShowDialog();
                }
                else
                {
                    PickNewDateOrGetRecomended pickNewDateOrGetRecomended = new PickNewDateOrGetRecomended(appointmentOperationDTO, PickedDoctor);
                    pickNewDateOrGetRecomended.ShowDialog();

                    AppointmentOperationDTO appointmentWithNewDate = pickNewDateOrGetRecomended.getAppointmentInfo();
                    if (appointmentWithNewDate == null)
                    {
                        this.NavigationService.Navigate(new ChoseTerminPage(PickedDoctor));
                    }
                    else
                    {
                        PickedDateTime = appointmentWithNewDate.getStartDate();
                    }
                }
            } else
            {
                AppointmentOperationDTO appointment = patientController.PostponeAppointment(Appointment);
                if (appointment != null)
                {
                    this.NavigationService.Navigate(new UpcomingServicesPage());
                    FeedbackModal feedback = new FeedbackModal("Usepešno odložen pregled", "Uspešno odložen pregled", "Izvšili ste uspešno odlaganje pregleda za " + appointment.getStartDate() + " kod doktora " + PickedDoctor.Name + " " + PickedDoctor.LastName + ". Proverite salu na dan izvršavanja pregleda, jer može doći do promene.", true);
                    feedback.ShowDialog();
                }
                else
                {
                    PickNewDateOrGetRecomended pickNewDateOrGetRecomended = new PickNewDateOrGetRecomended(Appointment, PickedDoctor);
                    pickNewDateOrGetRecomended.ShowDialog();

                    AppointmentOperationDTO appointmentWithNewDate = pickNewDateOrGetRecomended.getAppointmentInfo();
                    if (appointmentWithNewDate == null)
                    {
                        this.NavigationService.Navigate(new ChoseTerminPage(PickedDoctor));
                    }
                    else
                    {
                        PickedDateTime = appointmentWithNewDate.getStartDate();
                    }
                }
            }
        }
    }
}
