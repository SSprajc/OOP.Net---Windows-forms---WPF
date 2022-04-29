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
    public partial class PlayerStatsForm : Form
    {
        private static string apiMusko = "https://world-cup-json-2018.herokuapp.com/matches";
        private static string apiZensko = "http://worldcup.sfg.io/matches";

        InitSettings initialSettings = InitSettings.ReadSettingsFromFile();
        private string currentCulture;

        TeamResult favouriteTeam = TeamResult.GetTeamFromFile();

        public PlayerStatsForm()
        {
            InitializeComponent();
            LoadInitialSettings();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }


        private void LoadInitialSettings()
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

            Controls.Clear();
            InitializeComponent();
        }

        private async void PlayerStatsForm_Load(object sender, EventArgs e)
        {
            List<Player> playerStatsList = new List<Player>();
            pbPlayers.Value = 33;
            if (initialSettings.Prvenstvo == "Muško" || initialSettings.Prvenstvo == "Men")
            {
                if (initialSettings.IzvorPodataka == "Online")
                {
                    playerStatsList = await Player.GetPlayerInfoListAsync(apiMusko, favouriteTeam.FifaCode, favouriteTeam.Country);
                }
                else
                {
                    playerStatsList = await Player.GetPlayerInfoListFromFileAsync("men", favouriteTeam.FifaCode, favouriteTeam.Country);
                }

            }
            else if (initialSettings.Prvenstvo == "Žensko" || initialSettings.Prvenstvo == "Women")
            {
                if (initialSettings.IzvorPodataka == "Online")
                {
                    playerStatsList = await Player.GetPlayerInfoListAsync(apiZensko, favouriteTeam.FifaCode, favouriteTeam.Country);
                }
                else
                {
                    playerStatsList = await Player.GetPlayerInfoListFromFileAsync("women", favouriteTeam.FifaCode, favouriteTeam.Country);
                }
            }
            

            playerStatsList = playerStatsList.OrderByDescending(i => i.YellowCards).ToList();
            playerStatsList = playerStatsList.OrderByDescending(i => i.Goals).ToList();

            pbPlayers.Value = 66;

            foreach (var item in playerStatsList)
            {
                flpPlayers.Controls.Add(CreatePlayerStatsControl(item));
            }
            pbPlayers.Value = 100;
        }

        private PlayerStatsControl CreatePlayerStatsControl(Player player)
        {
            PlayerStatsControl psc = new PlayerStatsControl();
            psc.FillControlWithData(player);
            return psc;
        }


        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (flpPlayers.Width / 2), flpPlayers.Location.Y);
        }


        Bitmap MemoryImage;
        private void GetPrintArea(FlowLayoutPanel panel)
        {
            MemoryImage = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(MemoryImage, new Rectangle(0, 0, panel.Width, panel.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            GetPrintArea(flpPlayers);
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
    }
}
