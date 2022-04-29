using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodatkovniSloj.Models
{
    public class InitSettings
    {
        private const char DEL = '|';
        private static readonly string initialSettingsFilePath = @"..\..\..\InitialSettings.txt";
        public string Prvenstvo { get; set; }
        public string Jezik { get; set; }
        public string IzvorPodataka { get; set; }
        public string Rezolucija { get; set; }

        public InitSettings()
        {

        }

        public InitSettings(string prvenstvo, string jezik, string izvorPodataka, string rezolucija)
        {
            Prvenstvo = prvenstvo;
            Jezik = jezik;
            IzvorPodataka = izvorPodataka;
            Rezolucija = rezolucija;
        }

        public override string ToString() => $"{Prvenstvo}{DEL}{Jezik}{DEL}{IzvorPodataka}{DEL}{Rezolucija}";

        public static void SaveSettingsToFile(InitSettings initialSettings)
        {
            using (StreamWriter sw = new StreamWriter(initialSettingsFilePath))
            {
                sw.WriteLine(initialSettings.ToString());
            }

        }

        public static InitSettings ReadSettingsFromFile()
        {
            string[] data;
            using (StreamReader sr = new StreamReader(initialSettingsFilePath))
            {
                while (!sr.EndOfStream)
                {
                    data = sr.ReadLine().Split(DEL);
                    return new InitSettings(data[0], data[1], data[2], data[3]);
                }
            }
            return null;
        }
    }
}
