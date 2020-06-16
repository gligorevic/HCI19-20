using Controller.MedicalInfoControllers;
using Controller.MedicalServiceControllers;
using Dto.MedicalInfoDTOs;
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
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page, INotifyPropertyChanged
    {
        private ReportController reportController= new ReportController();

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

        private ReportDTO _report;

        public ReportDTO Report
        {
            get
            {
                return _report;
            }
            set
            {
                if (value != _report)
                {
                    _report = value;
                    OnPropertyChanged("Report");
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

        public ReportPage(AppointmentOperationDTO appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            Report = reportController.GetReportByAppointmentId(appointment.Id);
            Appointment = appointment;

        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
