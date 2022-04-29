using PodatkovniSloj.Models;
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

namespace WPF
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        private Player selectedPlayer = new Player();
        private MatchInformation selectedMatch = new MatchInformation();
        public PlayerControl(Player player, MatchInformation match)
        {
            InitializeComponent();
            FillControl(player);
            selectedMatch = match;
        }

        public void FillControl(Player player)
        {
            lblName.Content = player.Name;
            btnNumber.Content = player.ShirtNumber;
            selectedPlayer = player;
        }

        private void UserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayerInfoWindow playerInfoWindow = new PlayerInfoWindow();
            playerInfoWindow.LoadPlayerDetails(selectedPlayer, selectedMatch);
            playerInfoWindow.Show();
        }
    }
}
