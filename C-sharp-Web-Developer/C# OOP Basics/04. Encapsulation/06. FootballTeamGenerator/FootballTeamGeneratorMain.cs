using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FootballTeamGeneratorMain
{
    public static List<FootballTeam> footballTeams = new List<FootballTeam>();
    public static StringBuilder result = new StringBuilder();

    public static void Main()
    {
        var teamName = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        var footballTeam = new FootballTeam(teamName[1]);

        footballTeams.Add(footballTeam);

        var input = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        
        while (!input[0].Equals("END"))
        {
            try
            {
                CheckIfFootballTeamExist(input[1]);
                switch (input[0])
                {
                    case "Add":
                        AddPlayerToTeam(input);
                        break;
                    case "Remove":
                        RemovePlayerFromTeam(input);
                        break;
                    case "Rating":
                        GetTeamRating(input[1]);
                        break;
                    case "Team":
                        footballTeams.Add(footballTeam);
                        break;
                }
            }
            catch (Exception ex)
            {
                result.AppendLine(ex.Message);
            }
            input = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        Console.WriteLine(result);

    }

    private static void GetTeamRating(string teamName)
    {
        var footballTeamIndex = FindFootballTeamIndex(teamName);

        result.AppendLine($"{teamName} - {footballTeams[footballTeamIndex].AverageSkillLevelOfAllPlayersInTheTeam()}");
    }

    private static void RemovePlayerFromTeam(string[] input)
    {
        var teamName = input[1];
        var playerName = input[2];
        var footballTeamIndex = FindFootballTeamIndex(teamName);

        footballTeams[footballTeamIndex].RemovePlayer(playerName);
    }

    private static void AddPlayerToTeam(string[] input)
    {
        var teamName = input[1];
        var playerName = input[2];
        var copyPartArray = new string[5];

        // copying all the stats from the input to a new Array
        Array.Copy(input, 3, copyPartArray, 0, 5);

        var playerStats = copyPartArray.Select(double.Parse).ToArray();
    
        // using params I use as a parameter just single Array, not 5 parameters
        var stats = new Stats(playerStats);

        var player = new Player(playerName, stats);

        var footballTeamIndex = FindFootballTeamIndex(teamName);

        footballTeams[footballTeamIndex].AddPlayer(player);
    }

    private static int FindFootballTeamIndex(string teamName)
    {
        var footballTeamIndex = footballTeams.
            FindIndex(t => t.Name.Equals(teamName));
        return footballTeamIndex;
    }

    private static void CheckIfFootballTeamExist(string name)
    {
        bool exist = footballTeams.Any(t => t.Name.Equals(name));

        if (!exist)
        {
            throw new ArgumentException($"Team {name} does not exist.");
        }
    }
}