using PodatkovniSloj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.UserControls
{
    public partial class PlayerStatsControl : UserControl
    {
        public PlayerStatsControl()
        {
            InitializeComponent();
        }
        public void FillControlWithData(Player player)
        {
            lblIme.Text = player.Name;
            lblGolovi.Text = player.Goals.ToString();
            lblPojavljivanja.Text = player.MatchesPlayed.ToString();
            lblZutiKartoni.Text = player.YellowCards.ToString();

            if (File.Exists(@"..\..\..\RemainingPlayers.txt") && File.Exists(@"..\..\..\FavouritePlayers.txt"))
            {
                List<Player> remainingPlayersList = Player.LoadRemainingPlayersFromFile();
                List<Player> favouritePlayersList = Player.LoadFavouritePlayersFromFile();

                foreach (var p in remainingPlayersList)
                {
                    if (player.Name == p.Name)
                    {
                        pbPlayerPicture.ImageLocation = p.PlayerPhoto == "noPhoto" ? @"..\..\..\..\..\..\..\Resources\Player.png" : p.PlayerPhoto;
                    }
                }
                foreach (var p in favouritePlayersList)
                {
                    if (player.Name == p.Name)
                    {
                        pbPlayerPicture.ImageLocation = p.PlayerPhoto == "noPhoto" ? @"..\..\..\..\..\..\..\Resources\Player.png" : p.PlayerPhoto;
                    }
                }
            }
        }
    }
}
