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
using Bolnica.State;
using Class_Diagram___Hospital.Controller.MedicalServiceControllers.Abstract;
using Controller.MedicalServiceControllers;
using Dto.MedicalServiceDTOs;
using Dto.UserDTOs;
using Model.EquipmentAndRooms;
using Model.MedicalService;

namespace Bolnica.Modals
{
    /// <summary>
    /// Interaction logic for PickNewDateOrGetRecomended.xaml
    /// </summary>
    public partial class PickNewDateOrGetRecomended : Window, INotifyPropertyChanged
    {
        private IAppointmentController _appointmentController;

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


        private AppointmentOperationDTO Appointment { get; set; }

        public PickNewDateOrGetRecomended()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;
        }

        public PickNewDateOrGetRecomended(AppointmentOperationDTO appointment, DoctorDTO doctor)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;

            Appointment = appointment;
            TimesList = _appointmentController.GetAvailableAppointmentTimesByDateAndPatientAndDoctorId(appointment.StartDate, AppState.GetInstance().CurrentPatient.GetId(), appointment.DoctorId);
            if (doctor == null)
            {
                this.poruka.Text = "Neko je u međuvremenu zauzeo izabran termin kod lekara " + appointment.DoctorName;

            }
            else
            {
                this.poruka.Text = "Neko je u međuvremenu zauzeo izabran termin kod lekara " + doctor.Name + " " + doctor.LastName;

            }
        }

        private void PickMySelf_Handler(object sender, RoutedEventArgs e)
        {
            Appointment = null;
            this.Close();
        }

        private void Submit_Handler(object sender, RoutedEventArgs e)
        {
            Appointment.StartDate = Appointment.StartDate.Date + PickedTime;
            this.Close();
        }

        public AppointmentOperationDTO getAppointmentInfo()
        {
            return Appointment;
        }
    }
}
