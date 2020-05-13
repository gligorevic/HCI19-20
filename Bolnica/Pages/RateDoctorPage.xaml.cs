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
    public partial class RateDoctorPage : Page
    {
        private Doctor doctor { get; set; } 

        public RateDoctorPage(string docName)
        {
            InitializeComponent();
            doctor = new Doctor() { DoctorName = docName};
            this.DataContext = doctor;
        }



        private void IncreaseRate_Handler(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(doctor.PatiientRate.ToString());
            doctor.PatiientRate = doctor.PatiientRate + 1;
        }

        private void DecreaseRate_Handler(object sender, RoutedEventArgs e)
        {

        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }

    public class Doctor : INotifyPropertyChanged
    {
        public string DoctorName { get; set; }

        private int patientRate = 0;

        public int PatiientRate
        {
            get
            {
                return patientRate;
            }
            set
            {
                if (value != patientRate)
                {
                    patientRate = value;
                    OnPropertyChanged("PatientRate");
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
    }
}
