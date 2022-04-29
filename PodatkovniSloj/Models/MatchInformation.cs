using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PodatkovniSloj.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PodatkovniSloj.Models
{
    public partial class MatchInformation
    {
        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }

        [JsonProperty("fifa_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FifaId { get; set; }

        [JsonProperty("weather")]
        public Weather Weather { get; set; }

        [JsonProperty("attendance")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Attendance { get; set; }

        [JsonProperty("officials")]
        public List<string> Officials { get; set; }

        [JsonProperty("stage_name")]
        public StageName StageName { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("winner_code")]
        public string WinnerCode { get; set; }

        [JsonProperty("home_team")]
        public Team HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public Team AwayTeam { get; set; }

        [JsonProperty("home_team_events")]
        public List<TeamEvent> HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public List<TeamEvent> AwayTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }

        [JsonProperty("last_event_update_at")]
        public DateTimeOffset LastEventUpdateAt { get; set; }

        [JsonProperty("last_score_update_at")]
        public DateTimeOffset? LastScoreUpdateAt { get; set; }

        public static async Task<IEnumerable<MatchInformation>> GetMatchInfosAsync(string url)
        {
            HttpWebRequest wr = HttpWebRequest.Create(url) as HttpWebRequest;
            wr.ContentType = "application/json";
            wr.UserAgent = "Nothing";
            using (WebResponse webResponse = await wr.GetResponseAsync())
            {
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    var json = sr.ReadToEnd();
                    List<MatchInformation> list = JsonConvert.DeserializeObject<List<MatchInformation>>(json, PodatkovniSloj.Models.Converter.Settings);
                    return list;
                }
            }
        }

        public static async Task<IEnumerable<MatchInformation>> GetMatchInfoForTeamAsync(string url, string fifaCode)
        {
            string finalUrl = url + "/country?fifa_code=" + fifaCode;

            HttpWebRequest wr = HttpWebRequest.Create(finalUrl) as HttpWebRequest;
            wr.ContentType = "application/json";
            wr.UserAgent = "Nothing";
            using (WebResponse webResponse = await wr.GetResponseAsync())
            {
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    var json = sr.ReadToEnd();
                    List<MatchInformation> list = JsonConvert.DeserializeObject<List<MatchInformation>>(json, PodatkovniSloj.Models.Converter.Settings);
                    return list;
                }
            }
        }

        
        public static async Task<IEnumerable<MatchInformation>> GetMatchInfosFromFileAsync(string championshipType)
        {
            using (StreamReader sr = new StreamReader($@"..\..\..\PodatkovniSloj\Resources\{championshipType}\matches.json"))
            {
                var json = await sr.ReadToEndAsync();
                List<MatchInformation> list = JsonConvert.DeserializeObject<List<MatchInformation>>(json, PodatkovniSloj.Models.Converter.Settings);
                return list;
            }
        }

        public static async Task<IEnumerable<MatchInformation>> GetMatchInfosForTeamFromFileAsync(string fifaCode, string championshipType)
        {
            List<MatchInformation> allMatchesInfoList = (List<MatchInformation>)await GetMatchInfosFromFileAsync(championshipType);
            List<MatchInformation> teamMatchInfoList = new List<MatchInformation>();
            foreach (var item in allMatchesInfoList)
            {
                if (item.AwayTeam.Code == fifaCode || item.HomeTeam.Code == fifaCode)
                {
                    teamMatchInfoList.Add(item);
                }
            }
            return teamMatchInfoList;
        }
    }
    public partial class Team
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }

        public override string ToString() => $"{Country} ({Code})";
    }

    public partial class TeamEvent
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type_of_event")]
        public TypeOfEvent TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }

    public partial class TeamStatistics
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("attempts_on_goal")]
        public long AttemptsOnGoal { get; set; }

        [JsonProperty("on_target")]
        public long OnTarget { get; set; }

        [JsonProperty("off_target")]
        public long OffTarget { get; set; }

        [JsonProperty("blocked")]
        public long Blocked { get; set; }

        [JsonProperty("woodwork")]
        public long Woodwork { get; set; }

        [JsonProperty("corners")]
        public long Corners { get; set; }

        [JsonProperty("offsides")]
        public long Offsides { get; set; }

        [JsonProperty("ball_possession")]
        public long BallPossession { get; set; }

        [JsonProperty("pass_accuracy")]
        public long PassAccuracy { get; set; }

        [JsonProperty("num_passes")]
        public long NumPasses { get; set; }

        [JsonProperty("passes_completed")]
        public long PassesCompleted { get; set; }

        [JsonProperty("distance_covered")]
        public long DistanceCovered { get; set; }

        [JsonProperty("balls_recovered")]
        public long BallsRecovered { get; set; }

        [JsonProperty("tackles")]
        public long Tackles { get; set; }

        [JsonProperty("clearances")]
        public long? Clearances { get; set; }

        [JsonProperty("yellow_cards")]
        public long? YellowCards { get; set; }

        [JsonProperty("red_cards")]
        public long RedCards { get; set; }

        [JsonProperty("fouls_committed")]
        public long? FoulsCommitted { get; set; }

        [JsonProperty("tactics")]
        public Tactics Tactics { get; set; }

        [JsonProperty("starting_eleven")]
        public List<Player> StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public List<Player> Substitutes { get; set; }
    }

    public partial class Weather
    {
        [JsonProperty("humidity")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Humidity { get; set; }

        [JsonProperty("temp_celsius")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long WindSpeed { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }
    }

    public enum TypeOfEvent { Goal, GoalOwn, GoalPenalty, RedCard, SubstitutionIn, SubstitutionOut, YellowCard, YellowCardSecond };

    public enum Tactics { The3421, The343, The352, The4231, The4321, The433, The442, The451, The532, The541 };

    public enum StageName { Final, FirstStage, PlayOffForThirdPlace, QuarterFinals, RoundOf16, SemiFinals };

    public enum Status { Completed };

    public enum Time { FullTime };

    public enum Description { ClearNight, Cloudy, PartlyCloudy, PartlyCloudyNight, Sunny };


    public partial class MatchInformation
    {
        public static List<MatchInformation> FromJson(string json) => JsonConvert.DeserializeObject<List<MatchInformation>>(json, PodatkovniSloj.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<MatchInformation> self) => JsonConvert.SerializeObject(self, PodatkovniSloj.Models.Converter.Settings);
    }


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeOfEventConverter.Singleton,
                PositionConverter.Singleton,
                TacticsConverter.Singleton,
                StageNameConverter.Singleton,
                StatusConverter.Singleton,
                TimeConverter.Singleton,
                DescriptionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
