﻿using Bolnica.State;
using Class_Diagram___Hospital.Controller.MedicalInfoControllers.Abstract;
using Controller.MedicalInfoControllers;
using Dto.MedicalInfoDTOs;
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
    /// Interaction logic for RecepiesPage.xaml
    /// </summary>
    public partial class RecepiesPage : Page, INotifyPropertyChanged
    {
        private IMedicalRecordController _medicalRecordController;

        #region NotifyProperties

        private List<PrescriptionDTO> _prescriptions;

        public List<PrescriptionDTO> Prescriptions
        {
            get
            {
                return _prescriptions;
            }
            set
            {
                _prescriptions = value;
                OnPropertyChanged("Prescriptions");
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

        public RecepiesPage()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _medicalRecordController = app.MedicalRecordController;

            MedicalRecordDTO mr = _medicalRecordController.GetMedicalRecordByPatientId(AppState.GetInstance().CurrentPatient.GetId());
            Prescriptions = mr.Prescriptions;
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
