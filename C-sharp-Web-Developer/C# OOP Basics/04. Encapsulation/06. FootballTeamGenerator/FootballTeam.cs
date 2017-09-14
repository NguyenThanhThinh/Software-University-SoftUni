using System;
using System.Collections.Generic;
using System.Linq;

public class FootballTeam
{
    public List<Player> players { get; private set; }
    private string name;
    //private double rating;

    public FootballTeam(string name)
    {
        this.Name = name;
        players = new List<Player>();
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty. "); // may be there is space after the dot (.)
            }
            name = value;
        }
    }

    //public double Rating
    //{
    //    get
    //    {
    //        AverageSkillLevelOfAllPlayersInTheTeam();
    //        return rating;
    //    }

    //    private set
    //    {
    //        rating = value; // this may throw exception
    //    }
    //}

    public double AverageSkillLevelOfAllPlayersInTheTeam()
    {
        double averageSkillLevel = 0d;
        if (players.Count > 0)
        {
            averageSkillLevel = players.Average(p => p.OverallSkillLevel());
            //this.Rating = Math.Ceiling(averageSkillLevel);
        }
        return Math.Ceiling(averageSkillLevel);
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        var playerIndex = players.FindIndex(p => p.Name.Equals(playerName));

        if (playerIndex < 0)
        {
            throw new ArgumentException($"Player {playerName} is not in {name} team. "); // may be there is space after the dot (.)
        }
        players.RemoveAt(playerIndex);
    }
}