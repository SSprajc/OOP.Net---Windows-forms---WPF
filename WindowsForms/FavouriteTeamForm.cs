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

namespace WindowsForms
{
    public partial class FavouriteTeamForm : Form
    {
        private InitSettings initialSettings = new InitSettings();
        private static string apiMusko = "https://world-cup-json-2018.herokuapp.com/teams/results";
        private static string apiZensko = "http://worldcup.sfg.io/teams/results";
        private string currentCulture;

        public FavouriteTeamForm()
        {
            InitializeComponent();
            LoadCulture();
        }

        private void LoadCulture()
        {
            initialSettings = InitSettings.ReadSettingsFromFile();
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

        private async void FavouriteTeamForm_Load(object sender, EventArgs e)
        {
            List<TeamResult> teams = new List<TeamResult>();
            if (File.Exists(@"..\..\..\FavouritePlayers.txt"))
            {
                File.Delete(@"..\..\..\FavouritePlayers.txt");
            }
            pbTim.Value = 13;

            initialSettings = InitSettings.ReadSettingsFromFile();

            pbTim.Value = 33;

            if (initialSettings.Prvenstvo == "Muško" || initialSettings.Prvenstvo == "Men")
            {
                if (initialSettings.IzvorPodataka == "Online")
                {
                    teams = await TeamResult.GetDataFromUrlAsync(apiMusko);
                }
                else
                {
                    teams = await TeamResult.GetDataFromFileAsync("men");
                }
            }
            else if (initialSettings.Prvenstvo == "Žensko" || initialSettings.Prvenstvo == "Women")
            {
                if (initialSettings.IzvorPodataka == "Online")
                {
                    teams = await TeamResult.GetDataFromUrlAsync(apiZensko);
                }
                else
                {
                    teams = await TeamResult.GetDataFromFileAsync("women");
                }
            }
            pbTim.Value = 66;

            try
            {
                if (cbTim.Items.Count == 0)
                {
                    foreach (var item in teams)
                    {
                        cbTim.Items.Add(item);
                    }
                };
            }
            catch (Exception)
            {
                string message = currentCulture == "hr" ? "Greška u dohvaćanju podataka." : "Error in getting data.";
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pbTim.Value = 100;
        }

        private void btnNastavi_Click(object sender, EventArgs e)
        {
            TeamResult chosenTeam = new TeamResult();

            if (cbTim.SelectedItem != null)
            {
                chosenTeam = (TeamResult)cbTim.SelectedItem;
                TeamResult.SaveTeamToFile(chosenTeam);

                FavouritePlayersForm fpf = new FavouritePlayersForm();
                Hide();
                fpf.Show();
            }
            else
            {
                MessageBox.Show(currentCulture == "hr" ? "Niste odabrali najdraži tim" : "You didn't choose a favourite team");
            }

        }

        private void FavTeam_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
