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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public int ActiveStep { get; set; } = 1;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            ActiveStep = ActiveStep - 1;
            this.ContinueButton.Content = "Nastavi";
            this.ContinueButton.ToolTip = "Nastavi na unos lozinke";
            switch (ActiveStep)
            {
                case 0:
                    this.NavigationService.GoBack();
                    break;
                case 1:
                    this.forgotenButton.Text = "Zaboravljen mail?";
                    this.firstStep.Visibility = Visibility.Visible;
                    this.secondStep.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void GoToNextStep_Handler(object sender, RoutedEventArgs e)
        {
            if(ActiveStep == 2)
            {
                this.NavigationService.Navigate(new HomePage());
            }
            ActiveStep = ActiveStep + 1;
            this.ContinueButton.Content = "Uloguj se";
            this.ContinueButton.ToolTip = "Prijavi se na svoj nalog";
            this.forgotenButton.Text = "Zaboravljena lozinka?";
            this.firstStep.Visibility = Visibility.Hidden;
            this.secondStep.Visibility = Visibility.Visible;
        }

        private void Forgoten_Handler(object sender, MouseButtonEventArgs e)
        {
            switch(ActiveStep)
            {
                case 1:
                    this.NavigationService.Navigate(new ForgotenEmailPage());
                    break;

                case 2:
                    this.NavigationService.Navigate(new ForgotenPasswordPage());
                    break;
            }
        }
    }
}
