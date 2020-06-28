﻿using Bolnica.Modals;
using Bolnica.State;
using Class_Diagram___Hospital.Controller.MedicalServiceControllers.Abstract;
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
    /// Interaction logic for FinishedServicesPage.xaml
    /// </summary>
    public partial class UpcomingServicesPage : Page, INotifyPropertyChanged
    {
        private IAppointmentController _appointmentController;
        private IOperationController _operationController;
        private IHospitalizationController _hospitalizationController;

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

        public UpcomingServicesPage()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _operationController = app.OperationController;
            _hospitalizationController = app.HospitalizationController;
            _appointmentController = app.AppointmentController;

            PatientDTO curPatient = AppState.GetInstance().CurrentPatient;

            Appointments = _appointmentController.GetAllUpcomingAppointmentsByPatientId(curPatient.GetId());
            Operations = _operationController.getAllUpcomingOperationsByPatientId(curPatient.GetId());
            Hospitalizations = _hospitalizationController.getAllUpcomingHospitalizationsByPatientId(curPatient.GetId());
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ServicesPage());
        }

        private void CancelAppointment_Handler(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            AppointmentOperationDTO appointment = button.DataContext as AppointmentOperationDTO;

            CancelAppointmentModal modalWindow = new CancelAppointmentModal(appointment);
            modalWindow.ShowDialog();
            
            Appointments = _appointmentController.GetAllUpcomingAppointmentsByPatientId(AppState.GetInstance().CurrentPatient.GetId());
        }

        private void PostponeAppointment_Handler(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            AppointmentOperationDTO appointment = button.DataContext as AppointmentOperationDTO;

            this.NavigationService.Navigate(new ChoseTerminPage(appointment));
        }
    }
}
