using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for ChoseTerminPage.xaml
    /// </summary>
    public partial class ChoseTerminPage : Page, INotifyPropertyChanged
    {
        public string Priority { get; set; }

        private DateTime m_CleanLogsDeletionDate; //jos nije upotrebljeno
        public DateTime CleanLogsDeletionDate
        {
            get
            {
                return m_CleanLogsDeletionDate;
            }
            set
            {
                if (m_CleanLogsDeletionDate != value)
                {
                    m_CleanLogsDeletionDate = value;
                    OnPropertyChanged();
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public ChoseTerminPage(String doctorName)
        {
            InitializeComponent();
            Priority = "Doctor";
        }

        public ChoseTerminPage()
        {
            InitializeComponent();
            Priority = "Termin";
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Continue_Handler(object sender, RoutedEventArgs e)
        {
            if (Priority.Equals("Doctor"))
                this.NavigationService.Navigate(new ConfirmAppointmentPage());
            else
                this.NavigationService.Navigate(new ChoseDoctorPage("21.10.2020. 12:44"));
        }
    }

    
}
