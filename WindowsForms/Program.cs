using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    static class Program
    {
        private const string initalSettingsPath = @"..\..\..\InitialSettings.txt";
        private const string favouriteTeamPath = @"..\..\..\FavouriteTeam.txt";
        private const string favouritePlayersPath = @"..\..\..\FavouritePlayers.txt";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists(initalSettingsPath) && 
                File.Exists(favouriteTeamPath) &&
                File.Exists(favouritePlayersPath))
            {
                Application.Run(new FavouritePlayersForm());
            }
            else if (File.Exists(initalSettingsPath))
            {
                Application.Run(new FavouriteTeamForm());
            }
            else if (!File.Exists(initalSettingsPath))
            {
                Application.Run(new InitForm());
            }
        }
    }
}
