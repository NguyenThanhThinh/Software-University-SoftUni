using System;

public class Player
{
    private string name;
    public Stats stats { get; set; }

    public Player(string name, Stats stats)
    {
        this.Name = name;
        this.stats = stats;
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

    public double OverallSkillLevel()
    {
        return (stats.Dribble + stats.Endurance + stats.Passing + stats.Shooting + stats.Sprint) / 5;
    }
}