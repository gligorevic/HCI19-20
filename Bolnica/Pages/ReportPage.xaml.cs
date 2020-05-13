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
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage()
        {
            InitializeComponent();
            this.DataContext = new Appointment() { doctorName = "Doca Docic", date = "18:20 18.02.2020.", type="Opsti pregled"};
        }

        public class Appointment
        {
            public string doctorName { get; set; }

            public string date { get; set; }

            public string type { get; set; }
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
