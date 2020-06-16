using Bolnica.State;
using Class_Diagram___Hospital.Dto.UserDTOs;
using Controller.MedicalServiceControllers;
using Dto.MedicalServiceDTOs;
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
    /// Interaction logic for PassedServices.xaml
    /// </summary>
    public partial class PassedServicesPage : Page, INotifyPropertyChanged
    {
        private AppointmentController appointmentController = new AppointmentController();
        private OperationController operationController = new OperationController();
        private HospitalizationController hospitalizationController = new HospitalizationController();

        #region NotifyProperties

        private List<AppointmentOperationDTO> _appointments;

        public List<AppointmentOperationDTO> Appointments
        {
            get
            {
                return _appointments;
            }
            set
            {
                if (value != _appointments)
                {
                    _appointments = value;
                    OnPropertyChanged("Appointments");
                }
            }
        }

        private List<AppointmentOperationDTO> _operations;

        public List<AppointmentOperationDTO> Operations
        {
            get
            {
                return _operations;
            }
            set
            {
                if (value != _operations)
                {
                    _operations = value;
                    OnPropertyChanged("Appointments");
                }
            }
        }

        private List<HospitalizationDTO> _hospitalizations;

        public List<HospitalizationDTO> Hospitalizations
        {
            get
            {
                return _hospitalizations;
            }
            set
            {
                if (value != _hospitalizations)
                {
                    _hospitalizations = value;
                    OnPropertyChanged("Hospitalizations");
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

        public PassedServicesPage()
        {
            InitializeComponent();
            this.DataContext = this;
            PatientDTO curPatient = AppState.GetInstance().CurrentPatient;

            Appointments = appointmentController.getAllPasedAppointmentsByPatientId(curPatient.getId());
            Operations = operationController.getAllPasedOperationsByPatientId(curPatient.getId());
            Hospitalizations = hospitalizationController.getAllPasedHospitalizationsByPatientId(curPatient.getId());
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void RateDoctor_Handler(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            AppointmentOperationDTO appointment = button.DataContext as AppointmentOperationDTO;
            this.NavigationService.Navigate(new RateDoctorPage(appointment));
        }

        private void ShowReport_Handler(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            AppointmentOperationDTO appointment = button.DataContext as AppointmentOperationDTO;
            this.NavigationService.Navigate(new ReportPage(appointment));
        }
    }
}
