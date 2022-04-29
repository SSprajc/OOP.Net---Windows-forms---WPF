using PodatkovniSloj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.UserControls
{
    public partial class MatchControl : UserControl
    {
        public MatchControl()
        {
            InitializeComponent();
        }

        public void FillControlWithData(MatchInformation match)
        {
            lblHome.Text = match.HomeTeam.Country;
            lblHomeGoals.Text = match.HomeTeam.Goals.ToString();

            lblAway.Text = match.AwayTeam.Country;
            lblAwayGoals.Text = match.AwayTeam.Goals.ToString();

            lblStadium.Text = match.Location;
            lblLocation.Text = match.Venue;
            lblVisitors.Text = match.Attendance.ToString() + " people";

            switch (match.StageName)
            {
                case StageName.Final:
                    lblStage.Text = "Finals";
                    break;
                case StageName.FirstStage:
                    lblStage.Text = "First stage";
                    break;
                case StageName.PlayOffForThirdPlace:
                    lblStage.Text = "Playoff for 3rd place";
                    break;
                case StageName.QuarterFinals:
                    lblStage.Text = "Quarter finals";
                    break;
                case StageName.RoundOf16:
                    lblStage.Text = "Round of 16";
                    break;
                case StageName.SemiFinals:
                    lblStage.Text = "Semi finals";
                    break;
            }
        }

    }
}
