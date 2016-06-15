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
    /// Interaction logic for Einzelansicht.xaml
    /// </summary>
    public partial class Einzelansicht : UserControl
    {
        private MainWindow mainWindow;
        private static Boolean isEdited;
        private static Boolean isNewEntry;
        private static Einsatz einsatz;
        public Einzelansicht(int ID, MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();

            prepareDropdown();

            if (ID == 0)
                isNewEntry = true;
            else
            {
                isNewEntry = false;
                einsatz = Bibliothek.Einsatz_nach_ID(ID);
                inhaltAbfüllen();
            }

            setButtons();
        }

        private void inhaltAbfüllen()
        {
            TextBox_ProjektStart.Text = einsatz.Start.ToString();
            TextBox_ProjektEnde.Text = einsatz.Ende.ToString();

            ComboBox_ProjektBezeichnung.SelectedIndex = einsatz.Projekt.ID - 1;
            ComboBox_Mitarbeiter.SelectedIndex = einsatz.Mitarbeiter.ID - 1;
        }

        private void setButtons()
        {
            isEdited = false;

            mainWindow.Button_Abbrechen.IsEnabled = false;
            mainWindow.Button_Speichern.IsEnabled = false;
            mainWindow.Button_Neu.IsEnabled = true;
            mainWindow.Button_Suchen.IsEnabled = true;
        }

        private void prepareDropdown()
        {
            Bibliothek.Projekt_Alle().ForEach(delegate (Projekt projekt)
            {
                ComboBox_ProjektBezeichnung.Items.Add(projekt.Name);
            });

            Bibliothek.Mitarbeiter_Alle().ForEach(delegate (Mitarbeiter mitarbeiter)
            {
                ComboBox_Mitarbeiter.Items.Add(mitarbeiter.Name + " " + mitarbeiter.Vorname);
            });
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isEdited = true;
            mainWindow.Button_Abbrechen.IsEnabled = true;
            mainWindow.Button_Speichern.IsEnabled = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEdited = true;
            mainWindow.Button_Abbrechen.IsEnabled = true;
            mainWindow.Button_Speichern.IsEnabled = true;
        }

        private void TextBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text == "dd.mm.yyyy")
            {
                text.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text == "")
            {
                text.Text = "dd.mm.yyyy";
            }
        }
    }
}
