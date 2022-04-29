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
    public partial class VisitorForm : Form
    {
        private static string apiMusko = "https://world-cup-json-2018.herokuapp.com/matches";
        private static string apiZensko = "http://worldcup.sfg.io/matches";

        InitSettings initialSettings = InitSettings.ReadSettingsFromFile();
        private string currentCulture;

        TeamResult favouriteTeam = TeamResult.GetTeamFromFile();

        public VisitorForm()
        {
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


        private async void VisitorForm_Load(object sender, EventArgs e)
        {
            List<MatchInformation> matchInfos = new List<MatchInformation>();
            if (initialSettings.Prvenstvo == "Muško" || initialSettings.Prvenstvo == "Men")
            {
                if (initialSettings.IzvorPodataka == "Online")
                {
                    matchInfos = (List<MatchInformation>)await MatchInformation.GetMatchInfoForTeamAsync(apiMusko, favouriteTeam.FifaCode);
                }
                else
                {
                    matchInfos = (List<MatchInformation>)await MatchInformation.GetMatchInfosForTeamFromFileAsync(favouriteTeam.FifaCode, "men");
                }
                matchInfos = matchInfos.OrderByDescending(i => i.Attendance).ToList();
                pbVisitors.Value = 50;
                foreach (var item in matchInfos)
                {
                    flpVisitors.Controls.Add(CreateMatchInfoControl(item));
                }
                pbVisitors.Value = 100;
            }
            else if (initialSettings.Prvenstvo == "Žensko" || initialSettings.Prvenstvo == "Women")
            {
                if (initialSettings.IzvorPodataka == "Online")
                {
                    matchInfos = (List<MatchInformation>)await MatchInformation.GetMatchInfoForTeamAsync(apiZensko, favouriteTeam.FifaCode);
                }
                else
                {
                    matchInfos = (List<MatchInformation>)await MatchInformation.GetMatchInfosForTeamFromFileAsync(favouriteTeam.FifaCode, "women");
                }
                pbVisitors.Value = 50;
                foreach (var item in matchInfos)
                {
                    flpVisitors.Controls.Add(CreateMatchInfoControl(item));
                }
                pbVisitors.Value = 100;
            }
        }

        private MatchControl CreateMatchInfoControl(MatchInformation match)
        {
            MatchControl mic = new MatchControl();
            mic.FillControlWithData(match);
            mic.Anchor = AnchorStyles.None;
            return mic;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (flpVisitors.Width / 2), flpVisitors.Location.Y);
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            GetPrintArea(flpVisitors);
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
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
    }
}
