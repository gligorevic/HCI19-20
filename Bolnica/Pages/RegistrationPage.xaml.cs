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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public int ActiveStep { get; set; } = 1;

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void IncreaseActive_Step(object sender, RoutedEventArgs e)
        {
            ActiveStep = ActiveStep + 1;
   
            this.stepOneButton.Background = Brushes.White;
            this.stepTwoButton.Background = Brushes.White;
            this.firstStepForm.Visibility = Visibility.Hidden;
            this.secondStepForm.Visibility = Visibility.Hidden;
            switch (ActiveStep)
            {
                case 2:
                    this.secondStepForm.Visibility = Visibility.Visible;
                    this.stepTwoButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");
                    break;
                case 3:
                    this.thirdStepForm.Visibility = Visibility.Visible;
                    this.stepThreeButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");
                    this.ContinueButton.Content = "Završi registraciju";
                    break;
                case 4:
                    this.NavigationService.Navigate(new HomePage());
                    MessageBox.Show("Uspesna registracija");
                    break;
            }
        }

        private void DecreaseActive_Step(object sender, RoutedEventArgs e)
        {
            ActiveStep = ActiveStep - 1;


            this.ContinueButton.Content = "Nastavi";
            this.stepTwoButton.Background = Brushes.White;
            this.stepThreeButton.Background = Brushes.White;
            this.secondStepForm.Visibility = Visibility.Hidden;
            this.thirdStepForm.Visibility = Visibility.Hidden;
            switch (ActiveStep)
            {
                case 0:
                    this.NavigationService.GoBack();
                    break;
                case 1:
                    this.firstStepForm.Visibility = Visibility.Visible;
                    this.stepOneButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");
                    break;
                case 2:
                    this.secondStepForm.Visibility = Visibility.Visible;
                    this.stepTwoButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");
                    break;
            }
        }

        private void GoOn_Step1_Handler(object sender, RoutedEventArgs e)
        {
            ActiveStep = 1;
            this.stepTwoButton.Background = Brushes.White;
            this.stepThreeButton.Background = Brushes.White;
            this.stepOneButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");

            this.secondStepForm.Visibility = Visibility.Hidden;
            this.thirdStepForm.Visibility = Visibility.Hidden;
            this.firstStepForm.Visibility = Visibility.Visible;
        }

        private void GoOn_Step2_Handler(object sender, RoutedEventArgs e)
        {
            ActiveStep = 2;
            this.stepOneButton.Background = Brushes.White;
            this.stepThreeButton.Background = Brushes.White;
            this.stepTwoButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");

            this.thirdStepForm.Visibility = Visibility.Hidden;
            this.firstStepForm.Visibility = Visibility.Hidden;
            this.secondStepForm.Visibility = Visibility.Visible;  
        }

        private void GoOn_Step3_Handler(object sender, RoutedEventArgs e)
        {
            ActiveStep = 3;
            this.stepOneButton.Background = Brushes.White;
            this.stepTwoButton.Background = Brushes.White;
            this.stepThreeButton.Background = (Brush)new BrushConverter().ConvertFrom("#CAF4F4");

            this.firstStepForm.Visibility = Visibility.Hidden;
            this.secondStepForm.Visibility = Visibility.Hidden;
            this.thirdStepForm.Visibility = Visibility.Visible;
        }
    }
}
