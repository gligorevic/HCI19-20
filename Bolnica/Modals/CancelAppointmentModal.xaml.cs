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
using System.Windows.Shapes;

namespace Bolnica.Modals
{
    /// <summary>
    /// Interaction logic for CancelAppointmentModal.xaml
    /// </summary>
    public partial class CancelAppointmentModal : Window
    {
        public CancelAppointmentModal()
        {
            InitializeComponent();
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
