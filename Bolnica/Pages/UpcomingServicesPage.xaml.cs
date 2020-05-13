using Bolnica.Modals;
using System;
using System.Collections.Generic;
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
    public partial class UpcomingServicesPage : Page
    {
        public UpcomingServicesPage()
        {
            InitializeComponent();

            List<Appointment> items = new List<Appointment>();
            items.Add(new Appointment() { doctorName = "John Doe", Date = "12.12.2020", Room = "Soba 23", Type="Opsti Pregled"});
            items.Add(new Appointment() { doctorName = "Jane Doe", Date = "11.12.2021", Room = "Soba 21", Type = "Specijalisticki" });
            items.Add(new Appointment() { doctorName = "Sammy Doe", Date = "10.09.2020", Room = "Soba 13", Type = "Specijalisticki" });
            AppointmentDataBinding.ItemsSource = items;


            List<Operation> operations = new List<Operation>();
            operations.Add(new Operation() { doctorName = "Lekar Lekaric", Date = "06.06.2020", Room = "Soba 13", Type = "Tip operacije 1" });
            operations.Add(new Operation() { doctorName = "Milenko Lekaric", Date = "3.12.2021", Room = "Soba 11", Type = "Tip operacije 3" });
            operations.Add(new Operation() { doctorName = "Lekar Milenkic", Date = "05.08.2020", Room = "Soba 3", Type = "Tip operacije 2" });
            OperationDataBinding.ItemsSource = operations;

            List<Hospitalization> hospitalizations = new List<Hospitalization>();
            hospitalizations.Add(new Hospitalization() { startDate = "06.06.2020", endDate="26.06.2020", Room = "Soba 13"});
            hospitalizations.Add(new Hospitalization() { startDate = "06.08.2020", endDate = "26.08.2020", Room = "Soba 11" });
            hospitalizations.Add(new Hospitalization() { startDate = "26.06.2020", endDate = "16.07.2020", Room = "Soba 3" });
            HospitalizationDataBinding.ItemsSource = hospitalizations;
        }

        public class Appointment
        {
            public string doctorName { get; set; }

            public string Date { get; set; }

            public string Room { get; set; }

            public string Type { get; set; }
        }


        public class Operation
        {
            public string doctorName { get; set; }

            public string Date { get; set; }

            public string Room { get; set; }

            public string Type { get; set; }
        }

        public class Hospitalization
        {
            public string startDate { get; set; }

            public string endDate { get; set; }

            public string Room { get; set; }
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void CancelAppointment_Handler(object sender, RoutedEventArgs e)
        {
            CancelAppointmentModal modalWindow = new CancelAppointmentModal();
            modalWindow.ShowDialog();
        }
    }
}
