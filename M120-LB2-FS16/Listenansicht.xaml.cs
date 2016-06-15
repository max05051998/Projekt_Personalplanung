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
    /// Interaction logic for Listenansicht.xaml
    /// </summary>
    public partial class Listenansicht : UserControl
    {
        private MainWindow mainWindow;
        private List<ListenInhalt> listenInhalt;

        public Listenansicht(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            setButtons();

            prepareData();

            //übergibt listenInhalt der listenAnsicht
            listenAnsicht.DataContext = listenInhalt;
            
        }
        private void setButtons()
        {
            mainWindow.Button_Abbrechen.IsEnabled = false;
            mainWindow.Button_Speichern.IsEnabled = false;
            mainWindow.Button_Neu.IsEnabled = true;
            mainWindow.Button_Suchen.IsEnabled = true;
        }
        private void prepareData()
        {
            listenInhalt = new List<ListenInhalt>();

            Bibliothek.Einsatz_Alle().ForEach(delegate (Einsatz einsatz)
            {
                //Definiert neues Objekt inhalt aus Klasse ListenInhalt
                ListenInhalt inhalt = new ListenInhalt();
                //füllt die später anzuzeigenden Daten in inhalt
                inhalt.ID = einsatz.ID;
                inhalt.Mitarbeiter = einsatz.Mitarbeiter.Vorname + " " + einsatz.Mitarbeiter.Name;
                inhalt.ProjektBezeichnung = einsatz.Projekt.Name;
                inhalt.ProjektDauer = einsatz.Ende - einsatz.Start;
                inhalt.ProjektStart = einsatz.Start;
                inhalt.ProjektEnde = einsatz.Ende;

                //fügt die zuvor abgefüllten Daten dem listenInhalt hinzu
                listenInhalt.Add(inhalt);
            });
        }
    }
}
