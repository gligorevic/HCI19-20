using Bolnica.Modals;
using Bolnica.Pages;
using Bolnica.State;
using Controller.PatientControllers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Model.Doctor.InstructionAndPrescription;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private PatientController patientController = new PatientController();

        public HomePage()
        {
            InitializeComponent();
           
        }

        private void Show_Profile_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProfilePage());
        }

        private void Show_Services_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ServicesPage());
        }

        private void Schedule_Appointment_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ScheduleAppointmentPage());
        }

        private void Show_MedicalRecord_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MedicalRecordPage());
            
        }

        private void Generate_TherapyUse_Handler(object sender, RoutedEventArgs e)
        {
            List<PrescriptionItem> prescriptionItems = patientController.getPrescriptionItemsByPatientId(AppState.GetInstance().CurrentPatient.getId());

            string strPath = Environment.GetFolderPath(
                         System.Environment.SpecialFolder.DesktopDirectory);

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(strPath + "/therapy.pdf", FileMode.Create));
            document.Open();
            document.Add(new Chunk(""));

            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

            PdfPTable table = new PdfPTable(7);
            float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f, 4f};
            PdfPCell cell = new PdfPCell(new Phrase("Pregled nedeljne terapije"));
            cell.Colspan = 7;
            table.SetWidths(widths);
            table.WidthPercentage = 100;
            table.AddCell(cell);

            PdfPCell pon = new PdfPCell(new Phrase("Ponedeljak"));
            pon.Colspan = 1;
            PdfPCell uto = new PdfPCell(new Phrase("Utorak"));
            uto.Colspan = 1;
            PdfPCell ser = new PdfPCell(new Phrase("Sreda"));
            ser.Colspan = 1;
            PdfPCell cet = new PdfPCell(new Phrase("Cetvrtak"));
            cet.Colspan = 1;
            PdfPCell pet = new PdfPCell(new Phrase("Petak"));
            pet.Colspan = 1;
            PdfPCell sub = new PdfPCell(new Phrase("Subota"));
            sub.Colspan = 1;
            PdfPCell ned = new PdfPCell(new Phrase("Nedelja"));
            ned.Colspan = 1;
            
            table.AddCell(pon);
            table.AddCell(uto);
            table.AddCell(ser);
            table.AddCell(cet);
            table.AddCell(pet);
            table.AddCell(sub);
            table.AddCell(ned);

            foreach (PrescriptionItem p in prescriptionItems)
            {
                PdfPCell cellToAdd = new PdfPCell(new Phrase(p.getDrug().getName() + " " + p.getAmountToUse()));
                cellToAdd.Colspan = 1;

                PdfPCell cellEmpty = new PdfPCell(new Phrase("-"));
                cellEmpty.Colspan = 1;

                for (int i = 0; i < p.getTimeToUse().Count; i++)
                {
                    DayOfWeek day = p.getTimeToUse()[i];

                   

                    int z = 0;
                    if(day != DayOfWeek.Monday)
                    {
                        if (i != 0) z = (int)p.getTimeToUse()[i - 1] ; 
                        while(z < (int)day - 1) { z++; table.AddCell(cellEmpty); }
                        
                    }


                    table.AddCell(cellToAdd);

                    if (i == p.getTimeToUse().Count - 1)
                    {
                        i = (int)day == 0 ? 7 : (int)day;
                        while (i < 7)
                        {
                            i++;
                            table.AddCell(cellEmpty);
                        }
                    }
                }

            }


            document.Add(table);
            document.Close();

            FeedbackModal feedback = new FeedbackModal("Uspešno generisan pdf teraija", "Prikaz terapija", "Pdf u kojem se nalazi raspored uzimanja terapija nalazi se u fajlu therapy.pdf koji je na desktopu.", true);
            feedback.ShowDialog();
        }
    }
}
