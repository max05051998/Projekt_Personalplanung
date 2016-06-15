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

namespace M120_LB2_FS16
{
    /// <summary>
    /// Interaction logic for Kalenderansicht.xaml
    /// </summary>
    public partial class Kalenderansicht : UserControl
    {
        private MainWindow mainWindow;
        private DateTime today;

        public Kalenderansicht(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            today = DateTime.Today;

            setButtons();

            prepareCalendar();
            fillCalendar();
        }

        private void fillCalendar()
        {
            List<List<Einsatz>> kalenderListe = new List<List<Einsatz>>();

            switch(today.DayOfWeek.ToString())
            {
                case "Monday":
                    Label_Datum.Content = today.Date.ToString("dd/MM") + " - " + today.AddDays(6).Date.ToString("dd/MM/yyyy");
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(1)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(2)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(3)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(4)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(5)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(6)));
                    break;
                case "Tuesday":
                    Label_Datum.Content = today.Date.AddDays(-1).ToString("dd/MM") + " - " + today.AddDays(5).Date.ToString("dd/MM/yyyy");
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-1)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(1)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(2)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(3)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(4)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(5)));
                    break;
                case "Wednesday":
                    Label_Datum.Content = today.Date.AddDays(-2).ToString("dd/MM") + " - " + today.AddDays(4).Date.ToString("dd/MM/yyyy");
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-2)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-1)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(1)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(2)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(3)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(4)));
                    break;
                case "Thursday":
                    Label_Datum.Content = today.Date.AddDays(-3).ToString("dd/MM") + " - " + today.AddDays(3).Date.ToString("dd/MM/yyyy");
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-3)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-2)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-1)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(1)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(2)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(3)));
                    break;
                case "Friday":
                    Label_Datum.Content = today.Date.AddDays(-4).ToString("dd/MM") + " - " + today.AddDays(2).Date.ToString("dd/MM/yyyy");
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-4)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-3)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-2)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-1)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(1)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(2)));
                    break;
                case "Saturday":
                    Label_Datum.Content = today.Date.AddDays(-5).ToString("dd/MM") + " - " + today.AddDays(2).Date.ToString("dd/MM/yyyy");
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-5)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-4)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-3)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-2)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-1)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(1)));
                    break;
                case "Sunday":
                    Label_Datum.Content = today.Date.ToString("dd/MM") + " - " + today.AddDays(1).Date.ToString("dd/MM/yyyy");
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-6)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-5)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-4)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-3)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-2)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today.AddDays(-1)));
                    kalenderListe.Add(Bibliothek.Einsaetz_an_Datum(today));
                    break;
                default:
                    break;
            }

            for (int x = 1; x < 6; x++)
            {
                if (kalenderListe[x - 1].Count() != 0)
                {
                    kalenderListe[x - 1].ForEach(delegate (Einsatz einsatzZuPrüfen) {
                        for (int y = 0; y < 24; y++)
                        {
                            if (einsatzZuPrüfen.Start.Hour < y && einsatzZuPrüfen.Ende.Hour > y - 1)
                            {
                                Label inhaltLabel = new Label();
                                inhaltLabel.Content = einsatzZuPrüfen.ID;
                                Grid.SetRow(inhaltLabel, y);
                                Grid.SetColumn(inhaltLabel, x);
                                kalenderInhalt.Children.Add(inhaltLabel);
                            }
                        }
                    });
                }
            }
        }

        private void prepareCalendar()
        {
            for (int y = 1; y <= 24; y++)
            {
                for (int x = 1; x < 6; x++)
                {
                    Label CalenderLabel = new Label();
                    Grid.SetRow(CalenderLabel, y);
                    Grid.SetColumn(CalenderLabel, x);
                    kalenderInhalt.Children.Add(CalenderLabel);
                }
            }
        }

        private void setButtons()
        {
            mainWindow.Button_Abbrechen.IsEnabled = false;
            mainWindow.Button_Speichern.IsEnabled = false;
            mainWindow.Button_Neu.IsEnabled = true;
            mainWindow.Button_Suchen.IsEnabled = true;
        }

        private void Button_PrevWeek_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_NextWeek_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
