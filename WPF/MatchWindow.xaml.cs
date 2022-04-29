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
    /// Interaction logic for MatchWindow.xaml
    /// </summary>
    public partial class MatchWindow : Window
    {
        InitSettings initialSettings = InitSettings.ReadSettingsFromFile();
        private static string apiMusko = "https://world-cup-json-2018.herokuapp.com/teams/results";
        private static string apiZensko = "http://worldcup.sfg.io/teams/results";

        private static string apiMatchesMusko = "https://world-cup-json-2018.herokuapp.com/matches";
        private static string apiMatchesZensko = "http://worldcup.sfg.io/matches";

        private Team homeTeam = new Team();
        private Team awayTeam = new Team();

        private static MatchInformation selectedMatch = new MatchInformation();

        private string currentCulture;

        public MatchWindow()
        {
            LoadCulutre();
            InitializeComponent();
            SetResoulution(initialSettings.Rezolucija);
            var path = System.IO.Path.GetFullPath(@"..\..\..\");
            footballField.ImageSource = new BitmapImage(new Uri(@path + "WPF/Assets/footbalField.jpg"));
            Application.Current.MainWindow = this;
        }

        private void SetResoulution(string resolution)
        {
            int width;
            int height;

            if (resolution != "noSetResolution" && resolution != "Fullscreen")
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }

                string[] data = resolution.Split('x');
                width = int.Parse(data[0]);
                height = int.Parse(data[1]);

                Width = width;
                Height = height;
            }
            else if (resolution != "noSetResolution" && resolution == "Fullscreen")
            {
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
            }
        }

        private void LoadCulutre()
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<TeamResult> teamsList = new List<TeamResult>();
            pbTeams.Value = 33;

            if (initialSettings.Prvenstvo == "Muško" || initialSettings.Prvenstvo == "Men")
            {
                if (initialSettings.IzvorPodataka == "Online")
                {
                    teamsList = await TeamResult.GetDataFromUrlAsync(apiMusko);
                }
                else
                {
                    teamsList = await TeamResult.GetDataFromFileAsync("men");
                }
            }
            else if (initialSettings.Prvenstvo == "Žensko" || initialSettings.Prvenstvo == "Women")
            {
                if (initialSettings.IzvorPodataka == "Online")
                {
                    teamsList = await TeamResult.GetDataFromUrlAsync(apiZensko);
                }
                else
                {
                    teamsList = await TeamResult.GetDataFromFileAsync("women");
                }
            }
            pbTeams.Value = 66;


            try
            {
                teamsList = teamsList.OrderBy(i => i.Country).ToList();
                if (cbHomeTeam.Items.Count == 0 || cbAwayTeam.Items.Count == 0)
                {
                    foreach (var team in teamsList)
                    {
                        cbHomeTeam.Items.Add(team);
                        cbAwayTeam.Items.Add(team);

                        if (File.Exists(@"..\..\..\FavouriteTeam.txt"))
                        {
                            TeamResult favTeam = TeamResult.GetTeamFromFile();
                            if (team.Country == favTeam.Country)
                            {
                                cbHomeTeam.SelectedItem = team;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                string message = currentCulture == "hr" ? "Greška u dohvaćanju podataka." : "Error in getting data.";
                MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            pbTeams.Value = 100;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string message = currentCulture == "hr" ? "Stvarno želite izaći?" : "Are you sure you want to exit?";
            if (MessageBox.Show(message, "Exit", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
            }
        }

        private async void cbHomeTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pbTeams.Value = 0;
            List<Team> awayTeamsList = new List<Team>();
            List<MatchInformation> matchInfosList = new List<MatchInformation>();

            TeamResult selectedHomeTeam = (TeamResult)cbHomeTeam.SelectedItem;
            pbTeams.Value = 25;

            if (initialSettings.Prvenstvo == "Muško" || initialSettings.Prvenstvo == "Men")
            {
                if (initialSettings.IzvorPodataka == "Online")
                {
                    matchInfosList = (List<MatchInformation>)await MatchInformation.GetMatchInfoForTeamAsync(apiMatchesMusko, selectedHomeTeam.FifaCode);
                }
                else
                {
                    matchInfosList = (List<MatchInformation>)await MatchInformation.GetMatchInfosForTeamFromFileAsync(selectedHomeTeam.FifaCode, "men");
                }
            }
            else if (initialSettings.Prvenstvo == "Žensko" || initialSettings.Prvenstvo == "Women")
            {
                if (initialSettings.IzvorPodataka == "Online")
                {
                    matchInfosList = (List<MatchInformation>)await MatchInformation.GetMatchInfoForTeamAsync(apiMatchesZensko, selectedHomeTeam.FifaCode);
                }
                else
                {
                    matchInfosList = (List<MatchInformation>)await MatchInformation.GetMatchInfosForTeamFromFileAsync(selectedHomeTeam.FifaCode, "women");
                }
            }
            pbTeams.Value = 50;

            foreach (var item in matchInfosList)
            {
                if (selectedHomeTeam.Country == item.HomeTeamCountry)
                {
                    awayTeamsList.Add(item.AwayTeam);
                }
            }
            pbTeams.Value = 75;

            cbAwayTeam.Items.Clear();
            awayTeamsList = awayTeamsList.OrderBy(i => i.Country).ToList();
            foreach (var item in awayTeamsList)
            {
                cbAwayTeam.Items.Add(item);
            }

            if (cbAwayTeam.SelectedItem != null)
            {
                FillField(selectedMatch.HomeTeamStatistics.StartingEleven, selectedMatch.AwayTeamStatistics.StartingEleven, selectedMatch);
            }
            
            pbTeams.Value = 100;
            ResetScore();
        }

        private void FillField(List<Player> home, List<Player> away, MatchInformation match)
        {
            foreach (var igrac in home)
            {
                PlayerControl pc = new PlayerControl(igrac, match);
                
                switch (igrac.PlayerPosition.ToString())
                {
                    case ("Goalie"):
                        spGolmanH.Children.Add(pc);
                        break;
                    case ("Midfield"):
                        spVezniH.Children.Add(pc);
                        break;
                    case ("Forward"):
                        spNapadH.Children.Add(pc);
                        break;
                    case ("Defender"):
                        spObranaH.Children.Add(pc);
                        break;
                }

            }
            foreach (var igrac in away)
            {
                PlayerControl pc = new PlayerControl(igrac, match);

                switch (igrac.PlayerPosition.ToString())
                {
                    case ("Goalie"):
                        spGolmanA.Children.Add(pc);
                        break;
                    case ("Midfield"):
                        spVezniA.Children.Add(pc);
                        break;
                    case ("Forward"):
                        spNapadA.Children.Add(pc);
                        break;
                    case ("Defender"):
                        spObranaA.Children.Add(pc);
                        break;
                }

            }
        }

        private void ResetScore()
        {
            lblAwayTeamResult.Content = "0";
            lblHomeTeamResult.Content = "0";
        }

        private async void cbAwayTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAwayTeam.SelectedItem != null)
            {
                pbTeams.Value = 0;
                List<MatchInformation> allMatchInfosList = new List<MatchInformation>();

                TeamResult selectedHomeTeam = (TeamResult)cbHomeTeam.SelectedItem;
                awayTeam = (Team)cbAwayTeam.SelectedItem;

                MatchInformation match = new MatchInformation();
                pbTeams.Value = 13;

                if (initialSettings.Prvenstvo == "Muško" || initialSettings.Prvenstvo == "Men")
                {
                    if (initialSettings.IzvorPodataka == "Online")
                    {
                        allMatchInfosList = (List<MatchInformation>)await MatchInformation.GetMatchInfoForTeamAsync(apiMatchesMusko, selectedHomeTeam.FifaCode);
                    }
                    else
                    {
                        allMatchInfosList = (List<MatchInformation>)await MatchInformation.GetMatchInfosForTeamFromFileAsync(selectedHomeTeam.FifaCode, "men");
                    }
                }
                else if (initialSettings.Prvenstvo == "Žensko" || initialSettings.Prvenstvo == "Women")
                {
                    if (initialSettings.IzvorPodataka == "Online")
                    {
                        allMatchInfosList = (List<MatchInformation>)await MatchInformation.GetMatchInfoForTeamAsync(apiMatchesZensko, selectedHomeTeam.FifaCode);
                    }
                    else
                    {
                        allMatchInfosList = (List<MatchInformation>)await MatchInformation.GetMatchInfosForTeamFromFileAsync(selectedHomeTeam.FifaCode, "women");
                    }
                }
                pbTeams.Value = 33;

                selectedMatch = allMatchInfosList.Where(i => i.HomeTeamCountry == selectedHomeTeam.Country && i.AwayTeamCountry == awayTeam.Country).First();
                match = selectedMatch;
                pbTeams.Value = 66;

                ClearStackPanels();
                lblHomeTeamResult.Content = match.HomeTeam.Goals;
                lblAwayTeamResult.Content = match.AwayTeam.Goals;
                pbTeams.Value = 100;

                if (cbHomeTeam.SelectedItem != null)
                {
                    FillField(match.AwayTeamStatistics.StartingEleven, match.HomeTeamStatistics.StartingEleven, match);
                }
            }
        }

        private void ClearStackPanels()
        {
            spGolmanH.Children.Clear();
            spObranaH.Children.Clear();
            spVezniH.Children.Clear();
            spNapadH.Children.Clear();
            spGolmanA.Children.Clear();
            spObranaA.Children.Clear();
            spVezniA.Children.Clear();
            spNapadA.Children.Clear();
            
        }

        private void btnHomeTeamDetails_Click(object sender, RoutedEventArgs e)
        {
                if (cbHomeTeam.SelectedItem != null)
                {
                    pbTeams.Value = 0;

                    TeamResult selectedHomeTeam = (TeamResult)cbHomeTeam.SelectedItem;
                    pbTeams.Value = 30;

                    TeamInfoWindow window = new TeamInfoWindow();
                    window.FillWindowWithData(selectedHomeTeam);
                    pbTeams.Value = 100;

                    window.Show();
                }
                else
                {
                    MessageBox.Show(currentCulture == "hr" ? "Morate izabrati domaći tim!" : "You have to pick home team!");
                }
            }

        private async void btnAwayTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            if (cbAwayTeam.SelectedItem != null)
            {
                TeamResult awayTeamResults = new TeamResult();
                pbTeams.Value = 0;

                if (initialSettings.Prvenstvo == "Muško" || initialSettings.Prvenstvo == "Men")
                {
                    if (initialSettings.IzvorPodataka == "Online")
                    {
                        awayTeamResults = await TeamResult.GetDataForTeamFromUrlAsync(apiMusko, awayTeam.Country);
                    }
                    else
                    {
                        awayTeamResults = await TeamResult.GetDataForTeamFromFileAsync("men", awayTeam.Country);
                    }
                }
                else if (initialSettings.Prvenstvo == "Žensko" || initialSettings.Prvenstvo == "Women")
                {
                    if (initialSettings.IzvorPodataka == "Online")
                    {
                        awayTeamResults = await TeamResult.GetDataForTeamFromUrlAsync(apiZensko, awayTeam.Country);
                    }
                    else
                    {
                        awayTeamResults = await TeamResult.GetDataForTeamFromFileAsync("women", awayTeam.Country);
                    }
                }
                pbTeams.Value = 75;

                TeamInfoWindow window = new TeamInfoWindow();
                window.FillWindowWithData(awayTeamResults);
                pbTeams.Value = 100;

                window.Show();
            }
            else
            {
                MessageBox.Show(currentCulture == "hr" ? "Morate izabrati gostujući tim!" : "You have to pick a guest team!");
            }
        }

        private void btnPostavke_Click(object sender, RoutedEventArgs e)
        {
            InitWindow initWindow = new InitWindow();
            Hide();
            initWindow.Show();
        }
    }
}
