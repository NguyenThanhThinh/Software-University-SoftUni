using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class FootballStandings
{
    static void Main()
    {
        string key = Console.ReadLine();
        string line = Console.ReadLine();
        var teams = new Dictionary<string, Team>();


        while (line != "final")
        {
            var splitedLine = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string teamsPattern = key + @"{1,}(.*?)" + key + "{1,}";
            Regex regex = new Regex(teamsPattern);
            MatchCollection match = regex.Matches(line);

            string teamA = Reverse(match[0].Groups[1].Value).ToLower();
            string teamB = Reverse(match[1].Groups[1].Value).ToLower();
            var goalsBothTeams = splitedLine[2].Split(':');
            ulong goalsTeamA = ulong.Parse(goalsBothTeams[0]);
            ulong goalsTeamB = ulong.Parse(goalsBothTeams[1]);
            ulong pointsTeamA = 0;
            ulong pointsTeamB = 0;

            if (goalsTeamA > goalsTeamB)
            {
                pointsTeamA = 3;
            }
            else if (goalsTeamA == goalsTeamB)
            {
                pointsTeamA = 1;
                pointsTeamB = 1;
            }
            else
            {
                pointsTeamB = 3;
            }


            if (!teams.ContainsKey(teamA))
            {
                teams[teamA] = new Team();
                teams[teamA].goals += goalsTeamA;
                teams[teamA].points += pointsTeamA;
            }
            else
            {
                teams[teamA].goals += goalsTeamA;
                teams[teamA].points += pointsTeamA;
            }

            if (!teams.ContainsKey(teamB))
            {
                teams[teamB] = new Team();
                teams[teamB].goals += goalsTeamB;
                teams[teamB].points += pointsTeamB;
            }
            else
            {
                teams[teamB].goals += goalsTeamB;
                teams[teamB].points += pointsTeamB;
            }

            line = Console.ReadLine();
        }

        Console.WriteLine("League standings:");
        int i = 1;
        foreach (var team in teams.OrderByDescending(p => p.Value.points).ThenBy(n => n.Key))
        {
            Console.WriteLine($"{i}. {team.Key.ToUpper()} {team.Value.points}");
            i++;
        }
        Console.WriteLine("Top 3 scored goals:");
        var topScoredGoals = teams.OrderByDescending(g => g.Value.goals).ThenBy(n => n.Key).Take(3);
        foreach (var team in topScoredGoals)
        {
            Console.WriteLine($"- {team.Key.ToUpper()} -> {team.Value.goals}");
        }
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

class Team
{
    public ulong goals { get; set; }
    public ulong points { get; set; }
}

