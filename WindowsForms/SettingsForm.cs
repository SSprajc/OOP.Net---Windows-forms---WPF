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
    public partial class SettingsForm : Form
    {
        private string currentCulture;
        InitSettings oldSettings = InitSettings.ReadSettingsFromFile();
        

        public SettingsForm()
        {
            InitializeComponent();
            LoadInitialSettings();
        }

        private void LoadInitialSettings()
        {
            if (File.Exists(@"..\..\..\InitialSettings.txt"))
            {
                InitSettings initSettings = InitSettings.ReadSettingsFromFile();
                if (initSettings != null)
                {
                    if (initSettings.Jezik.ToString() == "English" || initSettings.Jezik.ToString() == "Engleski")
                    {
                        ChangeCulture("en");
                    }
                    else if (initSettings.Jezik.ToString() == "Croatian" || initSettings.Jezik.ToString() == "Hrvatski")
                    {
                        ChangeCulture("hr");
                    }
                    cbPrvenstvo.SelectedItem = initSettings.Prvenstvo;
                    cbJezik.SelectedItem = initSettings.Jezik;
                    cbIzvorPodataka.SelectedItem = initSettings.IzvorPodataka;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                SaveInitialSettings();
                InitSettings newSettings = InitSettings.ReadSettingsFromFile();
                ChangeCulture(cbJezik.SelectedItem.ToString() == "English" || cbJezik.SelectedItem.ToString() == "Engleski" ? "en" : "hr");
                Hide();
                if (newSettings.Prvenstvo != oldSettings.Prvenstvo)
                {
                    File.Delete(@"..\..\..\FavouritePlayers.txt");
                    FavouriteTeamForm favouriteTeamForm = new FavouriteTeamForm();
                    favouriteTeamForm.Show();
                }
                else
                {
                    FavouritePlayersForm form = new FavouritePlayersForm();
                    form.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveInitialSettings()
        {
            InitSettings initSettings = new InitSettings(cbPrvenstvo.Text, cbJezik.Text, cbIzvorPodataka.Text, "noSetResolution");
            InitSettings.SaveSettingsToFile(initSettings);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = currentCulture == "hr" ? "Stvarno želite izaći?" : "Are you sure you want to exit?";
            if (MessageBox.Show(message, "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
