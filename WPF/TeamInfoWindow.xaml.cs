using PodatkovniSloj.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for TeamInfoWindow.xaml
    /// </summary>
    public partial class TeamInfoWindow : Window
    {
        private string currentCulture;
        public TeamInfoWindow()
        {
            LoadCulture();
            InitializeComponent();
            Topmost = true;
        }
        private void LoadCulture()
        {
            if (File.Exists(@"..\..\..\InitialSettings.txt"))
            {
                InitSettings initialSettings = InitSettings.ReadSettingsFromFile();
                if (initialSettings != null)
                {
                    if (initialSettings.Jezik.ToString() == "English" || initialSettings.Jezik.ToString() == "Engleski")
                    {
                        ChangeCulture("en");
                    }
                    else if (initialSettings.Jezik.ToString() == "Croatian" || initialSettings.Jezik.ToString() == "Hrvatski")
                    {
                        ChangeCulture("hr");
                    }
                }
            }
        }

        private void ChangeCulture(string newCulture)
        {
            currentCulture = newCulture;

            Thread.CurrentThread.CurrentCulture = new CultureInfo(newCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(newCulture);

            InitializeComponent();
        }
        public void FillWindowWithData(TeamResult team)
        {
            lblNaziv.Content = team.Country;
            lblFifaKod.Content = team.FifaCode;
            lblBrojUtakmica.Content = team.GamesPlayed.ToString();
            lblBrojPobjeda.Content = team.Wins.ToString();
            lblBrojPoraza.Content = team.Losses.ToString();
            lblBrojNeodlucenih.Content = team.Draws.ToString();
            lblZabijeniGolovi.Content = team.GoalsFor.ToString();
            lblPrimljeniGolovi.Content = team.GoalsAgainst.ToString();
            lblGolRazlika.Content = team.GoalDifferential.ToString();
        }
    }
}
