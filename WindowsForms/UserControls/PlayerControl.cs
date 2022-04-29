using PodatkovniSloj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PodatkovniSloj.Models.Player;

namespace WindowsForms.UserControls
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
        }

        public void FillControlWithData(Player player)
        {
            lblName.Text = player.Name;
            lblNumber.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.PlayerPosition.ToString();
            if (!player.FavouritePlayer)
            {
                pnlFavourite.Hide();
            }
            else
            {
                pnlFavourite.Show();
            }
            if (!player.Captain)
            {
                pnlCaptain.Hide();
            }
            else
            {
                pnlCaptain.Show();
            }
            if (player.PlayerPhoto != "noPhoto")
            {
                pbPlayerImage.ImageLocation = player.PlayerPhoto;
            }
            SetPlayerSavedPhoto(player);
        }


        private void SetPlayerSavedPhoto(Player player)
        {
            List<Player> playersWithPhoto = Player.LoadPlayersWithPhotoFromFile();

            try
            {
                Player playerFromFile = playersWithPhoto.Where(i => i.Name == player.Name).First();
                pbPlayerImage.ImageLocation = playerFromFile.PlayerPhoto;
            }
            catch (Exception)
            {
                pbPlayerImage.ImageLocation = @"..\..\..\WindowsForms\Assets\Player.png";
            }
        }

        public Player GetPlayerFromControl()
        {
            Player p = new Player();
            p.Name = lblName.Text;
            p.ShirtNumber = int.Parse(lblNumber.Text);
            switch (lblPosition.Text)
            {
                case "Goalie":
                    p.PlayerPosition = Position.Goalie;
                    break;
                case "Defender":
                    p.PlayerPosition = Position.Defender;
                    break;
                case "Midfield":
                    p.PlayerPosition = Position.Midfield;
                    break;
                case "Forward":
                    p.PlayerPosition = Position.Forward;
                    break;
            }
            if (pnlCaptain.Visible)
            {
                p.Captain = true;
            }
            p.PlayerPhoto = pbPlayerImage.ImageLocation;
            return p;
        }

        public void ChangePlayerPicture(string picturePath)
        {
            pbPlayerImage.ImageLocation = picturePath;
        }

        public void ShowFavouritePlayerPanel()
        {
            pnlFavourite.Show();
        }

        public void HideFavouritePlayerPanel()
        {
            pnlFavourite.Hide();
        }
    }
}
