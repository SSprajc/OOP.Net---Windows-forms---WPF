using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodatkovniSloj.Models
{
    public class Player
    {
        private static readonly string favouritePlayersFilePath = @"..\..\..\FavouritePlayers.txt";
        private static readonly string remainingPlayersFilePath = @"..\..\..\RemainingPlayers.txt";
        private static readonly string playersWithPhotoFilePath = @"..\..\..\PlayersWithPhoto.txt";
        public enum Position { Defender, Forward, Goalie, Midfield };

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Position PlayerPosition { get; set; }    

        public bool FavouritePlayer { get; set; }
        public string PlayerPhoto { get; set; }

        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int MatchesPlayed { get; set; }

        public override string ToString()
        {
            if (PlayerPhoto == null)
            {
                return $"{Name}|{ShirtNumber}|{PlayerPosition}|{Captain}|{FavouritePlayer}|noPhoto";
            }
            else
            {
                return $"{Name}|{ShirtNumber}|{PlayerPosition}|{Captain}|{FavouritePlayer}|{PlayerPhoto}";
            }
        }

        
        public static async Task<List<Player>> GetPlayerListAsync(string url, string country)
        {
            List<MatchInformation> allMatchInfoList = (List<MatchInformation>)await MatchInformation.GetMatchInfosAsync(url);
            MatchInformation firstCountryMatch = allMatchInfoList.Find(i => i.HomeTeamStatistics.Country == country);

            List<Player> startingEleven = firstCountryMatch.HomeTeamStatistics.StartingEleven;
            List<Player> substitutes = firstCountryMatch.HomeTeamStatistics.Substitutes;

            List<Player> playersList = startingEleven.Concat(substitutes).ToList();
            return playersList;
        }

        public static async Task<List<Player>> GetPlayerInfoListAsync(string url, string fifaCode, string country)
        {
            List<MatchInformation> allMatchInfoList = (List<MatchInformation>)await MatchInformation.GetMatchInfoForTeamAsync(url, fifaCode);
            List<Player> playerInfoList = await GetPlayerListAsync(url, country);
            foreach (Player p in playerInfoList)
            {
                foreach (MatchInformation match in allMatchInfoList)
                {
                    if (match.HomeTeamCountry == country)
                    {
                        foreach (Player pl in match.HomeTeamStatistics.StartingEleven)
                        {
                            if (p.Name == pl.Name)
                            {
                                p.MatchesPlayed++;
                            }
                        }
                        foreach (TeamEvent item in match.HomeTeamEvents)
                        {
                            if (item.Player == p.Name)
                            {
                                if (item.TypeOfEvent == TypeOfEvent.YellowCard || item.TypeOfEvent == TypeOfEvent.YellowCardSecond)
                                {
                                    p.YellowCards++;
                                }
                                else if (item.TypeOfEvent == TypeOfEvent.Goal || item.TypeOfEvent == TypeOfEvent.GoalPenalty)
                                {
                                    p.Goals++;
                                }
                                else if (item.TypeOfEvent == TypeOfEvent.SubstitutionIn)
                                {
                                    p.MatchesPlayed++;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Player pl in match.AwayTeamStatistics.StartingEleven)
                        {
                            if (p.Name == pl.Name)
                            {
                                p.MatchesPlayed++;
                            }
                        }
                        foreach (TeamEvent item in match.AwayTeamEvents)
                        {
                            if (item.Player == p.Name)
                            {
                                if (item.TypeOfEvent == TypeOfEvent.YellowCard || item.TypeOfEvent == TypeOfEvent.YellowCardSecond)
                                {
                                    p.YellowCards++;
                                }
                                else if (item.TypeOfEvent == TypeOfEvent.Goal || item.TypeOfEvent == TypeOfEvent.GoalPenalty)
                                {
                                    p.Goals++;
                                }
                                else if (item.TypeOfEvent == TypeOfEvent.SubstitutionIn)
                                {
                                    p.MatchesPlayed++;
                                }
                            }
                        }
                    }
                }
            }
            return playerInfoList;
        }

        
        public static async Task<List<Player>> GetPlayerListFromFileAsync(string championshipType, string country)
        {
            List<MatchInformation> allMatchInfoList = (List<MatchInformation>)await MatchInformation.GetMatchInfosFromFileAsync(championshipType);
            MatchInformation firstCountryMatch = allMatchInfoList.Find(i => i.HomeTeamStatistics.Country == country);

            List<Player> startingEleven = firstCountryMatch.HomeTeamStatistics.StartingEleven;
            List<Player> substitutes = firstCountryMatch.HomeTeamStatistics.Substitutes;

            List<Player> playersList = startingEleven.Concat(substitutes).ToList();
            return playersList;
        }

        public static async Task<List<Player>> GetPlayerInfoListFromFileAsync(string championshipType, string fifaCode, string country)
        {
            List<MatchInformation> allMatchInfoList = (List<MatchInformation>)await MatchInformation.GetMatchInfosForTeamFromFileAsync(fifaCode, championshipType);
            List<Player> playerInfoList = await GetPlayerListFromFileAsync(championshipType, country);
            foreach (Player p in playerInfoList)
            {
                foreach (MatchInformation match in allMatchInfoList)
                {
                    if (match.HomeTeamCountry == country)
                    {
                        foreach (Player pl in match.HomeTeamStatistics.StartingEleven)
                        {
                            if (p.Name == pl.Name)
                            {
                                p.MatchesPlayed++;
                            }
                        }
                        foreach (TeamEvent item in match.HomeTeamEvents)
                        {
                            if (item.Player == p.Name)
                            {
                                if (item.TypeOfEvent == TypeOfEvent.YellowCard || item.TypeOfEvent == TypeOfEvent.YellowCardSecond)
                                {
                                    p.YellowCards++;
                                }
                                else if (item.TypeOfEvent == TypeOfEvent.Goal || item.TypeOfEvent == TypeOfEvent.GoalPenalty)
                                {
                                    p.Goals++;
                                }
                                else if (item.TypeOfEvent == TypeOfEvent.SubstitutionIn || item.TypeOfEvent == TypeOfEvent.SubstitutionOut)
                                {
                                    p.MatchesPlayed++;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Player pl in match.AwayTeamStatistics.StartingEleven)
                        {
                            if (p.Name == pl.Name)
                            {
                                p.MatchesPlayed++;
                            }
                        }
                        foreach (TeamEvent item in match.AwayTeamEvents)
                        {
                            if (item.Player == p.Name)
                            {
                                if (item.TypeOfEvent == TypeOfEvent.YellowCard || item.TypeOfEvent == TypeOfEvent.YellowCardSecond)
                                {
                                    p.YellowCards++;
                                }
                                else if (item.TypeOfEvent == TypeOfEvent.Goal || item.TypeOfEvent == TypeOfEvent.GoalPenalty)
                                {
                                    p.Goals++;
                                }
                                else if (item.TypeOfEvent == TypeOfEvent.SubstitutionIn || item.TypeOfEvent == TypeOfEvent.SubstitutionOut)
                                {
                                    p.MatchesPlayed++;
                                }
                            }
                        }
                    }
                }
            }
            return playerInfoList;
        }


        public static void SaveFavouritePlayers(List<Player> favouritePlayersList)
        {
            using (StreamWriter sw = new StreamWriter(favouritePlayersFilePath))
            {
                foreach (var player in favouritePlayersList)
                {
                    player.FavouritePlayer = true;
                    sw.WriteLine(player.ToString());
                }
            }
        }

        public static void SaveRemainingPlayers(List<Player> remainingPlayersList)
        {
            using (StreamWriter sw = new StreamWriter(remainingPlayersFilePath))
            {
                foreach (var player in remainingPlayersList)
                {
                    sw.WriteLine(player.ToString());
                }
            }
        }

        public static void SavePlayerWithPhoto(List<Player> playersWithPhotoList)
        {
            using (StreamWriter sw = File.AppendText(playersWithPhotoFilePath))
            {
                foreach (var player in playersWithPhotoList)
                {
                    sw.WriteLine(player.ToString());
                }
            }
        }


        private static Player GetPlayerFromLine(string line)
        {
            string[] data = line.Split('|');

            Player p = new Player();
            p.Name = data[0];
            p.ShirtNumber = int.Parse(data[1]);
            switch (data[2])
            {
                case "Goalie":
                    p.PlayerPosition = Position.Goalie;
                    break;
                case "Defender":
                    p.PlayerPosition = Position.Defender;
                    break;
                case "Midfield":
                    p.PlayerPosition = Position.Midfield;
                    break;
                case "Forward":
                    p.PlayerPosition = Position.Forward;
                    break;
            }
            p.Captain = bool.Parse(data[3].ToString());
            p.FavouritePlayer = bool.Parse(data[4].ToString());
            p.PlayerPhoto = data[5];

            return p;
        }

        public static List<Player> LoadFavouritePlayersFromFile()
        {
            List<Player> favouritePlayers = new List<Player>();
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(favouritePlayersFilePath))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
            }
            foreach (var line in lines)
            {
                favouritePlayers.Add(GetPlayerFromLine(line));
            }
            return favouritePlayers;
        }

        public static List<Player> LoadRemainingPlayersFromFile()
        {
            List<Player> remainingPlayers = new List<Player>();
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(remainingPlayersFilePath))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
            }
            foreach (var line in lines)
            {
                remainingPlayers.Add(GetPlayerFromLine(line));
            }
            return remainingPlayers;
        }

        public static List<Player> LoadPlayersWithPhotoFromFile()
        {
            List<Player> playersWithPhoto = new List<Player>();
            List<string> lines = new List<string>();
            if (File.Exists(playersWithPhotoFilePath))
            {
                using (StreamReader sr = new StreamReader(playersWithPhotoFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        lines.Add(sr.ReadLine());
                    }
                    foreach (var line in lines)
                    {
                        playersWithPhoto.Add(GetPlayerFromLine(line));
                    }
                }
            }
            return playersWithPhoto;
        }
    }
}
