﻿using Class_Diagram___Hospital.Controller.Abstract;
using Controller.PatientControllers;
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
using System.Windows.Shapes;

namespace Bolnica.Modals
{
    /// <summary>
    /// Interaction logic for CancelAppointmentModal.xaml
    /// </summary>
    public partial class CancelAppointmentModal : Window, INotifyPropertyChanged
    {
        private IPatientController _patientController;

        #region NotifyProperties

        private AppointmentOperationDTO _appointment;

        public AppointmentOperationDTO Appointment
        {
            get
            {
                return _appointment;
            }
            set
            {
                if (value != _appointment)
                {
                    _appointment = value;
                    OnPropertyChanged("Appointment");
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


        public CancelAppointmentModal(AppointmentOperationDTO appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _patientController = app.PatientController;

            Appointment = appointment;
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void CancelAppointment_Handler(object sender, RoutedEventArgs e)
        {
            _patientController.CancelAppointment(Appointment.Id);
            this.Close();
            FeedbackModal feedback = new FeedbackModal("Uspešno otkazan pregled", "Uspešno otkazivanje", "Izvršili ste uspešno otkazivanje pregleda koji je trebao da bude izvršen datuma " + Appointment.StartDate + " kod lekara " + Appointment.DoctorName + ".", true);
            feedback.ShowDialog();
        }
    }
}
