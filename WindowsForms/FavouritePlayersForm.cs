using PodatkovniSloj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.UserControls;

namespace WindowsForms
{
    public partial class FavouritePlayersForm : Form
    {
        private static string apiMusko = "https://world-cup-json-2018.herokuapp.com/matches";
        private static string apiZensko = "http://worldcup.sfg.io/matches";

        private static readonly string favouritePlayersFilePath = @"..\..\..\FavouritePlayers.txt";
        private static readonly string remainingPlayersFilePath = @"..\..\..\RemainingPlayers.txt";

        InitSettings initialSettings = InitSettings.ReadSettingsFromFile();
        private string currentCulture;

        TeamResult favouriteTeam = TeamResult.GetTeamFromFile();
        private PlayerControl selectedPlayer;

        public FavouritePlayersForm()
        {
            LoadCulture();
        }

        private void LoadCulture()
        {
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

        private void ChangeCulture(string newCulture)
        {
            currentCulture = newCulture;

            Thread.CurrentThread.CurrentCulture = new CultureInfo(newCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(newCulture);

            Controls.Clear();
            InitializeComponent();
        }

        private async void FavouritePlayersForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(remainingPlayersFilePath) && File.Exists(favouritePlayersFilePath))
            {
                LoadSavedPlayers();
            }
            else
            {
                List<Player> playersList = new List<Player>();
                if (initialSettings.Prvenstvo == "Muško" || initialSettings.Prvenstvo == "Men")
                {
                    TeamResult favouriteTeam = TeamResult.GetTeamFromFile();
                    pbIgraci.Value = 33;

                    if (initialSettings.IzvorPodataka == "Online")
                    {
                        playersList = await Player.GetPlayerListAsync(apiMusko, favouriteTeam.Country);
                    }
                    else
                    {
                        playersList = await Player.GetPlayerListFromFileAsync("men", favouriteTeam.Country);
                    }
                    pbIgraci.Value = 66;


                    foreach (var item in playersList)
                    {
                        flpIgraci.Controls.Add(CreatePlayerControl(item));
                    }

                    pbIgraci.Value = 100;
                }
                else if (initialSettings.Prvenstvo == "Žensko" || initialSettings.Prvenstvo == "Women")
                {
                    TeamResult favouriteTeam = TeamResult.GetTeamFromFile();
                    pbIgraci.Value = 33;

                    if (initialSettings.IzvorPodataka == "Online")
                    {
                        playersList = await Player.GetPlayerListAsync(apiZensko, favouriteTeam.Country);
                    }
                    else
                    {
                        playersList = await Player.GetPlayerListFromFileAsync("women", favouriteTeam.Country);
                    }
                    pbIgraci.Value = 66;

                    foreach (var item in playersList)
                    {
                        flpIgraci.Controls.Add(CreatePlayerControl(item));
                    }
                    pbIgraci.Value = 100;
                }
            }
        }
        private PlayerControl CreatePlayerControl(Player player)
        {
            PlayerControl pc = new PlayerControl();
            pc.FillControlWithData(player);
            pc.ContextMenuStrip = player.FavouritePlayer ? cmsFavPlayer : cmsPlayer;
            pc.MouseDown += Pc_MouseDown;
            return pc;
        }

        private void LoadSavedPlayers()
        {
            List<Player> remainingPlayers = Player.LoadRemainingPlayersFromFile();
            foreach (var player in remainingPlayers)
            {
                flpIgraci.Controls.Add(CreatePlayerControl(player));
            }

            List<Player> favouritePlayers = Player.LoadFavouritePlayersFromFile();
            foreach (var player in favouritePlayers)
            {
                flpNajdraziIgraci.Controls.Add(CreatePlayerControl(player));
            }
        }




        private void cmsPlayer_Opened(object sender, EventArgs e)
        {
            if (selectedPlayer != null)
            {
                selectedPlayer.BorderStyle = BorderStyle.None;
            }

            PlayerControl playerControl = (sender as ContextMenuStrip).SourceControl as PlayerControl;
            playerControl.BorderStyle = BorderStyle.Fixed3D;
            selectedPlayer = playerControl;
        }

        private void dodajUFavorite_Clicked(object sender, EventArgs e)
        {
            flpNajdraziIgraci.Controls.Add(selectedPlayer);
            foreach (PlayerControl item in flpNajdraziIgraci.Controls)
            {
                item.ShowFavouritePlayerPanel();
                item.ContextMenuStrip = cmsFavPlayer;
            }
            flpIgraci.Controls.Remove(selectedPlayer);
            selectedPlayer.BorderStyle = BorderStyle.None;
            selectedPlayer = null;
        }


        private void cmsFavPlayer_Opened(object sender, EventArgs e)
        {
            if (selectedPlayer != null)
            {
                selectedPlayer.BorderStyle = BorderStyle.None;
            }
            PlayerControl playerControl = (sender as ContextMenuStrip).SourceControl as PlayerControl;
            playerControl.BorderStyle = BorderStyle.Fixed3D;
            selectedPlayer = playerControl;
        }
        private void ukloniIzFav_Clicked(object sender, EventArgs e)
        {
            flpIgraci.Controls.Add(selectedPlayer);
            flpNajdraziIgraci.Controls.Remove(selectedPlayer);

            selectedPlayer.ContextMenuStrip = cmsPlayer;
            selectedPlayer.HideFavouritePlayerPanel();
            selectedPlayer.BorderStyle = BorderStyle.None;
            selectedPlayer = null;
        }
        private void urediSliku_Clicked(object sender, EventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pictures|*.bmp;*.jpg;*.jpeg;*.png;|All files|*.*";
            ofd.InitialDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\WindowsForms\Assets";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedPlayer.ChangePlayerPicture(ofd.FileName);
            }
        }



        private void FavouritePlayers_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = currentCulture == "hr" ? "Stvarno želite izaći?" : "Are you sure you want to exit?";
            if (MessageBox.Show(message, "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            List<Player> playersWithPhoto = new List<Player>();

            List<Player> favouritePlayersList = new List<Player>();
            foreach (PlayerControl playerControl in flpNajdraziIgraci.Controls)
            {
                favouritePlayersList.Add(playerControl.GetPlayerFromControl());

                if (playerControl.GetPlayerFromControl().PlayerPhoto != null &&
                    playerControl.GetPlayerFromControl().PlayerPhoto != @"..\..\..\WindowsForms\Assets\Player.png")
                {
                    playersWithPhoto.Add(playerControl.GetPlayerFromControl());
                }
            }

            List<Player> remainingPlayersList = new List<Player>();
            foreach (PlayerControl playerControl in flpIgraci.Controls)
            {
                remainingPlayersList.Add(playerControl.GetPlayerFromControl());

                if (playerControl.GetPlayerFromControl().PlayerPhoto != null &&
                    playerControl.GetPlayerFromControl().PlayerPhoto != @"..\..\..\WindowsForms\Assets\Player.png")
                {
                    playersWithPhoto.Add(playerControl.GetPlayerFromControl());
                }
            }


            if (favouritePlayersList.Count < 3)
            {
                MessageBox.Show(currentCulture == "hr" ? "Morate odabrati najmanje 3 igrača" : "You have to pick at least 3 favourite players");
            }
            else
            {
                Player.SaveFavouritePlayers(favouritePlayersList);
                Player.SaveRemainingPlayers(remainingPlayersList);
                Player.SavePlayerWithPhoto(playersWithPhoto);

                MessageBox.Show(currentCulture == "hr" ? "Najdraži igrači su spremljeni" : "Favourite players are saved");
            }
        }

        private void btnRangListaIgraca_Click(object sender, EventArgs e)
        {
            PlayerStatsForm form = new PlayerStatsForm();
            form.Show();
        }

        private void btnRangListPosjetitelja_Click(object sender, EventArgs e)
        {
            VisitorForm form = new VisitorForm();
            form.Show();
        }

        private void btnPostavke_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            Hide();
            form.Show();
        }

        private void Pc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                PlayerControl playerControl = (PlayerControl)sender;
                playerControl.DoDragDrop(playerControl, DragDropEffects.Move);
            }
        }

        private void flpSviIgraciDD(object sender, DragEventArgs e)
        {
            PlayerControl playerControl = (PlayerControl)e.Data.GetData(typeof(PlayerControl));
            playerControl.ContextMenuStrip = cmsPlayer  ;
            playerControl.HideFavouritePlayerPanel();
            flpIgraci.Controls.Add(playerControl);
        }

        private void flpSviIgraci_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flpNajdraziIgraciDD(object sender, DragEventArgs e)
        {
            PlayerControl playerControl = (PlayerControl)e.Data.GetData(typeof(PlayerControl));
            playerControl.ContextMenuStrip = cmsFavPlayer;
            playerControl.ShowFavouritePlayerPanel();
            flpNajdraziIgraci.Controls.Add(playerControl);
        }

        private void flpNajdraziIgraci_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect =DragDropEffects.Move;
        }
    }
}
