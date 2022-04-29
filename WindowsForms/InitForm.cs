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
    public partial class InitForm : Form
    {
        private string currentCulture;

        public InitForm()
        {
            InitializeComponent();
            LoadInitialSettings();
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

                    cbPrvenstvo.SelectedItem = initialSettings.Prvenstvo;
                    cbJezik.SelectedItem = initialSettings.Jezik;
                    cbIzvorPodataka.SelectedItem = initialSettings.IzvorPodataka;
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

        private void InitForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cbPrvenstvo.SelectedItem != null && cbJezik.SelectedItem != null && cbIzvorPodataka.SelectedItem != null)
            {
                try
                {

                    SaveInitialSettings();
                    ChangeCulture(cbJezik.SelectedItem.ToString() == "English" || cbJezik.SelectedItem.ToString() == "Engleski" ? "en" : "hr");
                    Hide();
                    FavouriteTeamForm favouriteTeamForm = new FavouriteTeamForm();
                    favouriteTeamForm.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show(currentCulture == "hr" ? "Niste odabrali sve potrebne stavke." : "You didn't choose every property");
                }
            }
            else
            {
                MessageBox.Show(currentCulture == "hr" ? "Niste odabrali sve potrebne stavke." : "You didn't choose every property");
            }
        }

        

        private void SaveInitialSettings()
        {
            InitSettings initialSettings = new InitSettings(cbPrvenstvo.Text, cbJezik.Text, cbIzvorPodataka.Text, "noSetResolution");
            InitSettings.SaveSettingsToFile(initialSettings);
        }
    }
}
