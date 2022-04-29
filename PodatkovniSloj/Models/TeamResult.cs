using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PodatkovniSloj.Models
{
    public partial class TeamResult
    {
        private static readonly string favouriteTeamFilePath = @"..\..\..\FavouriteTeam.txt";

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public object AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        [JsonProperty("wins")]
        public long Wins { get; set; }

        [JsonProperty("draws")]
        public long Draws { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("games_played")]
        public long GamesPlayed { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("goals_for")]
        public long GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        public long GoalDifferential { get; set; }

        public override string ToString() => $"{Country} ({FifaCode})";

        public static void SaveTeamToFile(TeamResult tr)
        {
            using (StreamWriter sw = new StreamWriter(favouriteTeamFilePath))
            {
                sw.WriteLine(tr.ToString());
            }
        }

        public static TeamResult GetTeamFromFile()
        {
            TeamResult tr = new TeamResult();
            string[] data;
            using (StreamReader sr = new StreamReader(favouriteTeamFilePath))
            {
                while (!sr.EndOfStream)
                {
                    data = sr.ReadLine().Split(' ');
                    tr.Country = data[0];
                    tr.FifaCode = data[1].Replace('(', ' ').Replace(')', ' ').Trim();
                    return tr;
                }
            }
            return null;
        }

        public static async Task<List<TeamResult>> GetDataFromUrlAsync(string url)
        {
            try
            {
                HttpWebRequest wr = WebRequest.Create(url) as HttpWebRequest;

                wr.ContentType = "application/json";
                wr.UserAgent = "Nothing";
                using (WebResponse webResponse = await wr.GetResponseAsync())
                {
                    using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                    {
                        var timoviJson = sr.ReadToEnd();
                        List<TeamResult> list = JsonConvert.DeserializeObject<List<TeamResult>>(timoviJson);
                        list.OrderBy(i => i.Country).ToList();
                        return list;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static async Task<List<TeamResult>> GetDataFromFileAsync(string championshipType)
        {
            using (StreamReader sr = new StreamReader($@"..\..\..\PodatkovniSloj\Resources\{championshipType}\results.json"))
            {
                var json = await sr.ReadToEndAsync();
                List<TeamResult> list = JsonConvert.DeserializeObject<List<TeamResult>>(json);
                return list;
            }
        }

        public static async Task<TeamResult> GetDataForTeamFromUrlAsync(string url, string country)
        {
            List<TeamResult> teamResultsList = await GetDataFromUrlAsync(url);
            return teamResultsList.Where(i => i.Country == country).First();
        }

        public static async Task<TeamResult> GetDataForTeamFromFileAsync(string championshipType, string country)
        {
            List<TeamResult> teamResultsList = await GetDataFromFileAsync(championshipType);
            return teamResultsList.Where(i => i.Country == country).First();
        }


    }
}
