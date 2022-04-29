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
    /// Interaction logic for PlayerInfoWindow.xaml
    /// </summary>
    public partial class PlayerInfoWindow : Window
    {
        private string currentCulture;
        public PlayerInfoWindow()
        {
            InitializeComponent();
            LoadCulture();
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

        public void LoadPlayerDetails(Player player, MatchInformation match)
        {
            List<TeamEvent> homeTeamEvents = match.HomeTeamEvents;
            List<TeamEvent> awayTeamEvents = match.AwayTeamEvents;

            int goalNumber = 0;
            int yellowCardNumber = 0;

            foreach (var teamEvent in homeTeamEvents)
            {
                if (teamEvent.Player == player.Name)
                {
                    switch (teamEvent.TypeOfEvent)
                    {
                        case TypeOfEvent.Goal:
                            goalNumber++;
                            break;
                        case TypeOfEvent.GoalOwn:
                            goalNumber++;
                            break;
                        case TypeOfEvent.GoalPenalty:
                            goalNumber++;
                            break;
                        case TypeOfEvent.YellowCard:
                            yellowCardNumber++;
                            break;
                        case TypeOfEvent.YellowCardSecond:
                            yellowCardNumber++;
                            break;
                    }
                }
            }

            foreach (var teamEvent in awayTeamEvents)
            {
                if (teamEvent.Player == player.Name)
                {
                    switch (teamEvent.TypeOfEvent)
                    {
                        case TypeOfEvent.Goal:
                            goalNumber++;
                            break;
                        case TypeOfEvent.GoalOwn:
                            goalNumber++;
                            break;
                        case TypeOfEvent.GoalPenalty:
                            goalNumber++;
                            break;
                        case TypeOfEvent.YellowCard:
                            yellowCardNumber++;
                            break;
                        case TypeOfEvent.YellowCardSecond:
                            yellowCardNumber++;
                            break;
                    }
                }
            }

            lblPlayerName.Content = player.Name;
            lblNumber.Content = player.ShirtNumber.ToString();
            lblPosition.Content = player.PlayerPosition.ToString();
            lblGoalNumber.Content = goalNumber.ToString();
            lblYellowCardNumber.Content = yellowCardNumber.ToString();
            //SetPlayerPhoto(player);

            if (currentCulture == "hr")
            {
                lblCaptain.Content = player.Captain ? "Da" : "Ne";
            }
            else
            {
                lblCaptain.Content = player.Captain ? "Yes" : "No";
            }

        }

        public void SetPlayerPhoto(Player player)
        {
        }
    }
}
