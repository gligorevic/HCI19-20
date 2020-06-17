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
    /// Interaction logic for HelpModal.xaml
    /// </summary>
    public partial class HelpModal : Window
    {
        private Dictionary<String, String> helpPages = new Dictionary<String, String>() { { "Registracija ili logovanje?", "RegistrateOrLoginPage" }, { "Kako se ulogovati?", "LoginPage" }, {"Kako se registrovati?", "RegistrationPage" }, {"Uputstva pocetne stranice", "HomePage" }, { "Kako zakazati pregled?", "ScheduleAppointmentPage" }, {"Kako izmeniti podatke o profilu?", "EditProfilePage"}, {"Kako odloziti ili otkazati pregled?", "UpcomingServicesPage" }, { "Kako oceniti lekara ili pogledati izvestaj?", "PassedServicesPage" } };

        public HelpModal(String currFrame)
        {
            InitializeComponent();



            setParent(currFrame);

        }

        private void setParent(String currFrame)
        {
            Breadcrumb.SelectedIndex = 2;
            Separator.Visibility = Visibility.Visible;
            parent.Children.Clear();
            CurrentPath.Content = helpPages.FirstOrDefault(x => x.Value == currFrame).Key;

            TextBlock title = new TextBlock();
            title.FontSize = 18;

            TextBlock explanation = new TextBlock();
            explanation.TextWrapping = TextWrapping.Wrap;
            explanation.FontSize = 16;
            if(CurrentPath.Content == null)
            {
                Breadcrumb.SelectedIndex = 0;
                GoTo_HelpHome(null, null);
            } 
            
            title.Text = CurrentPath.Content.ToString();
            switch (currFrame)
            {
                case "LoginPage":
                    explanation.Text = "\nUnesite svoj email sa kojim ste se registrovali na sistem u polje oznaceno labelom 'Email'. Potom pritisnite dugme nastavi. \n\nUnesite lozinku u polje oznaceno labelom 'Lozinka'. Pritisnite dugme prijavi se. \n";
                    break;
                case "RegistrateOrLoginPage":
                    explanation.Text = "\nUkoliko nemate nalog odaberite opciju registurj se klkom na dugme 'Registruj se' kako bi kreirali nalog.\nU suprotnom, ako vec imate nalog odaberite opciju uloguj se kako bi se prijavili sa vec postojecim nalogom.\n";
                    break;
                case "RegistrationPage":
                    explanation.Text = "\nPotrebno je uneti tražene podatke u sva polja za unos osim u polje broj stana. U toku unosa podataka bićete navođeni, ukoliko neki od unosa unesete u lošem formatu, crvenim natpisima ispod polja za unos.\n";
                    break;
                case "HomePage":
                    explanation.Text = "\nZakazivanje pregleda\nDa biste zakazali pregled odaberite opciju zakazi pregled klikom na istoimeno dugme.\n\nPregled zdravstvenog kartona\nDa biste videli svoj zdravstveni karton kliknite na istoimeno dugme\n\nPregled nedeljne terapije\nDa biste videli nedeljnu terapiju kliknite na dugme generiši termine terapije. Generisani pdf će biti lociran na vašem desktopu.\n\nPregledi i operacije\nDa vidite svoje predstojece i protekle medicinske usluge kliknite dugme Moji pregledi i oprecije.\n\nPregled korisničkog profila\nZa pregled korisničkog profila potrebno je da kliknete na dugme korisnički profil.";
                    break;
                case "ScheduleAppointmentPage":
                    explanation.Text = "\nPregled mozete zakazati na dva nacina.\n\nPrvi nacin\nOdaberite prvo lekara, pa onda termin za koji je taj lekar slobodan i potvrdite svoj odabir.\n\nDrugi nacin\nOdaberite prvo termin pa onda lekara koji je slobodan za taj termin.";
                    break;
                case "EditProfilePage":
                    explanation.Text = "\nDa biste izmenili podatke o svom korisnickom profilu potrebno je da odete na stranicu korisnicki profil sto mozete uciniti sa pocetne stranice.\nOdaberite opciju izmeni profil i izmenite zeljene podatke.\n\nPolja za unos ce vas navoditi da unesete trazeni format za ta polja.\n\nKad izmenite zeljene podatke kliknite na dugme sacuvaj izmene.";
                    break;
                case "UpcomingServicesPage":
                    explanation.Text = "\nOtkazivanje pregleda\nDa biste otkazali pregled potrebno je da odete na stranicu predstojece medicinske usluge, gde u tabu pregledi mozete naci u izlistanim pregledima dugme otkazi.\n\nKada kliknete dugme otkazi otvorice se modal za potvrdu, kada potvrdite otkazali ste pregled.\n\nOdlaganje pregleda\nDa biste odlozili pregled potrebno je da odete na stranicu predstojece medicinske usluge, gde u tabu pregledi u okviru izlistanih pregleda mozete za svaki odabrati opciju odlozi klikom na istoimeno dugme. Po kliku na dugme proces za odlaganje pregleda je isti kao i proces za zakazivanje gde se prvo bira termin pa onda lekar.";
                    break;
                case "PassedServicesPage":
                    explanation.Text = "\nOcenjivanje lekara\n\nDa biste ocenili lekara potrebno je da odete na stranicu prethodnih medicinskih usluga, gde su izlistani izvrseni pregledi. Klikom na dugme oceni lekara otvara se prozor u kojem se ispisuje ime lekara i postojeca ocena ukoliko ste ga vec ocenili. Po izboru ocene potvrdite unos i uspesno ste ocenili lekara.\n\nPregled izvestaja\nDa biste pogledali izvestaj potrebno je da ste pozicionirani na stranici proteklih medicinskih usluga, gde su izlistani pregledi koji su prosli. Klikom na dugme pogledaj izvestaj koje se nalazi u okviru svakok od pregleda mozete pogledati izvestaj sa tog pregleda.";
                    break;
            }
            parent.Children.Add(title);
            parent.Children.Add(explanation);


        }

        private void Close_Handler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GoTo_HelpHome(object sender, MouseButtonEventArgs e)
        {
            parent.Children.Clear();
            TextBlock listHeader = new TextBlock();
            listHeader.FontSize = 18;
            listHeader.Margin = new Thickness(0, 5, 0, 5);
            listHeader.Text = "Odaberite jednu od opcija";
            parent.Children.Add(listHeader);

            ListBox listBox = new ListBox();
            foreach(String page in helpPages.Keys)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = page;
                item.PreviewMouseDown += new MouseButtonEventHandler(HelpPage_Choosed_Handler);
                parent.Children.Add(item);
            }
            CurrentPath.Content = "";
            Separator.Visibility = Visibility.Hidden;

        }

        private void HelpPage_Choosed_Handler(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = e.Source as ListBoxItem;
            
            setParent(helpPages[lbi.Content.ToString()]);
        }

    }
}
