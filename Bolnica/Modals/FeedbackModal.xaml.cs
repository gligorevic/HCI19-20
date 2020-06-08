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
    /// Interaction logic for FeedbackModal.xaml
    /// </summary>
    public partial class FeedbackModal : Window
    {
        public FeedbackModal(String title, String textTittle, String text, Boolean info)
        {
            InitializeComponent();
            this.Title = title;

            if (info)
                this.infoIcon.Visibility = Visibility.Visible;
            else
                this.dangerIcon.Visibility = Visibility.Visible;

            this.text.Text = text;
            this.textTittle.Text = textTittle;
        }

        private void CloseModal_Handler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
