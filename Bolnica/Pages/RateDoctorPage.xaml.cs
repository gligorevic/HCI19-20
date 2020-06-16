using Bolnica.Modals;
using Class_Diagram___Hospital.Controller.DoctorControllers;
using Dto.DoctorDTOs;
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
    /// Interaction logic for OceniLekaraPage.xaml
    /// </summary>
    public partial class RateDoctorPage : Page, INotifyPropertyChanged
    {
        private RatingController ratingController = new RatingController();


        #region NotifyProperties
        private int _rate;

        public int Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                if (value != _rate)
                {
                    _rate = value;
                    OnPropertyChanged("Rate");
                }
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        public RateDoctorPage(AppointmentOperationDTO appointment)
        {
            
            InitializeComponent();
            this.DataContext = this;

            RateDTO rateDTO = new RateDTO();
            rateDTO.PatientId = appointment.PatientId;
            rateDTO.DoctorId = appointment.DoctorId;
            
            Appointment = appointment;
            RateDTO exRate = ratingController.getExistingRate(rateDTO);
            if(exRate == null)
            {
                Rate= 0;
            } else
            {
                Rate = exRate.Rate;
            }
        }

        private void IncreaseRate_Handler(object sender, RoutedEventArgs e)
        {
            if(Rate < 5)
                Rate++;
            
        }

        private void DecreaseRate_Handler(object sender, RoutedEventArgs e)
        {
            if(Rate > 1)
                Rate--;
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Submit_Handler(object sender, RoutedEventArgs e)
        {
            RateDTO rateDTO = new RateDTO();
            rateDTO.PatientId = Appointment.PatientId;
            rateDTO.DoctorId = Appointment.DoctorId;
            rateDTO.Rate = Rate;

            ratingController.rateDoctor(rateDTO);
            this.NavigationService.GoBack();
            FeedbackModal feedback = new FeedbackModal("Uspešno ocenjivanje", "Uspešno ocenjivanje", "Izvršili ste uspešno ocenjivanje lekara " + Appointment.DoctorName + " sa ocenom " + Rate + ".", true);
            feedback.ShowDialog();
        }
    }
}
