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
    /// Interaction logic for InitWindow.xaml
    /// </summary>
    public partial class InitWindow : Window
    {
        private string currentCulture;
        public InitWindow()
        {
            InitializeComponent();
            LoadInitSettings();
            LoadResolution();
        }

        private void LoadResolution()
        {
            if (File.Exists(@"..\..\..\InitialSettings.txt"))
            {
                InitSettings initialSettings = InitSettings.ReadSettingsFromFile();
                SetWindowResolution(initialSettings.Rezolucija);
            }
        }

        private void SetWindowResolution(string rezolucija)
        {
            int width;
            int height;

            if (rezolucija != "noSetResolution" && rezolucija != "Fullscreen")
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }

                string[] data = rezolucija.Split('x');
                width = int.Parse(data[0]);
                height = int.Parse(data[1]);

                Width = width;
                Height = height;
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            else if (rezolucija != "noSetResolution" && rezolucija == "Fullscreen")
            {
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
            }
        }

        private void LoadInitSettings()
        {
            if (File.Exists(@"..\..\..\InitialSettings.txt"))
            {
                InitSettings initialSettings = InitSettings.ReadSettingsFromFile();
                if (initialSettings != null)
                {
                    if (initialSettings.Jezik.ToString() == "English" || initialSettings.Jezik.ToString() == "Engleski")
                    {
                        ChangeCulture("en");
                        rbtnEng.IsChecked = true;
                    }
                    else if (initialSettings.Jezik.ToString() == "Croatian" || initialSettings.Jezik.ToString() == "Hrvatski")
                    {
                        ChangeCulture("hr");
                        rbtnHrv.IsChecked = true;
                    }

                    switch (initialSettings.Prvenstvo)
                    {
                        case "Muško":
                            rbtnMan.IsChecked = true;
                            break;
                        case "Men":
                            rbtnMan.IsChecked= true;
                            break;
                        case "Žensko":
                            rbtnWom.IsChecked = true;
                            break;
                        case "Women":
                            rbtnWom.IsChecked= true;
                            break;
                    }

                    switch (initialSettings.IzvorPodataka)
                    {
                        case "Online":
                            cbIzvorPodataka.SelectedIndex = 0;
                            break;
                        case "Offline":
                            cbIzvorPodataka.SelectedIndex = 1;
                            break;
                    }

                    if (initialSettings.Rezolucija != null || initialSettings.Rezolucija != "noSetResolution")
                    {
                        switch (initialSettings.Rezolucija)
                        {
                            case "800x650":
                                cbRezolucija.SelectedIndex = 0;
                                break;
                            case "1080x720":
                                cbIzvorPodataka.SelectedIndex = 1;
                                break;
                            case "1280x720":
                                cbIzvorPodataka.SelectedIndex = 2;
                                break;
                            case "Fullscreen":
                                cbIzvorPodataka.SelectedIndex = 3;
                                break;
                        }
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

        private void cbRezolucija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string resolution = cbRezolucija.SelectedValue.ToString();
            SetWindowResolution(resolution);
        }

        private void btnSpremi_Click(object sender, RoutedEventArgs e)
        {
            if ((rbtnMan.IsChecked == true || rbtnWom.IsChecked == true) && (rbtnEng.IsChecked == true || rbtnHrv.IsChecked == true) && 
                cbIzvorPodataka.SelectedItem != null && cbRezolucija.SelectedItem != null)
            {
                try
                {
                    if (File.Exists(@"..\..\..\InitialSettings.txt"))
                    {
                        string message = currentCulture == "hr" ? "Jeste li sigurni?" : "Are you sure?";
                        if (MessageBox.Show(message, "Settings", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            SaveInitialSettings();
                        }
                    }

                    SaveInitialSettings();
                }
                catch (Exception)
                {
                    MessageBox.Show(currentCulture == "hr" ? "Odaberite sve stavke." : "Choose prefered settings.");
                }
            }
            else
            {
                MessageBox.Show(currentCulture == "hr" ? "Odaberite sve stavke." : "Choose prefered settings.");
            }
        }

        private void SaveInitialSettings()
        {
            string prvenstvo = "Muško";
            string jezik = "Hrvatski";
            if (rbtnMan.IsChecked == true)
            {
                prvenstvo = "Muško";
            }
            else if (rbtnWom.IsChecked == true)
            {
                prvenstvo = "Žensko";
            }
            if (rbtnEng.IsChecked == true)
            {
                jezik = "Engleski";
            }
            else if (rbtnHrv.IsChecked == true)
            {
                jezik = "Hrvatski";
            }
            InitSettings initialSettings = new InitSettings(prvenstvo, jezik, cbIzvorPodataka.Text, cbRezolucija.Text);
            InitSettings.SaveSettingsToFile(initialSettings);

            ChangeCulture(jezik == "Engleski" ? "en" : "hr");

            MatchWindow matchWindow = new MatchWindow();    
            Hide();
            matchWindow.Show();
        }
    }
}
