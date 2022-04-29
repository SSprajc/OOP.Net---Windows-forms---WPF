using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (!File.Exists(@"..\..\..\InitialSettings.txt"))
            {
                InitWindow window = new InitWindow();
                window.InitializeComponent();
                window.Show();
            }
            else
            {
                MatchWindow window = new MatchWindow();
                window.InitializeComponent();
                window.Show();
            }
        }
    }
}
