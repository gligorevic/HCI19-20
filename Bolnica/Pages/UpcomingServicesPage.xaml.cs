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
using FontAwesome.WPF;

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
            lvDataBinding.ItemsSource = items;


            List<Operation> operations = new List<Operation>();
            operations.Add(new Operation() { doctorName = "Lekar Lekaric", Date = "06.06.2020", Room = "Soba 13", Type = "Tip operacije 1" });
            operations.Add(new Operation() { doctorName = "Milenko Lekaric", Date = "3.12.2021", Room = "Soba 11", Type = "Tip operacije 3" });
            operations.Add(new Operation() { doctorName = "Lekar Milenkic", Date = "05.08.2020", Room = "Soba 3", Type = "Tip operacije 2" });
            OperationDataBinding.ItemsSource = operations; 
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

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
