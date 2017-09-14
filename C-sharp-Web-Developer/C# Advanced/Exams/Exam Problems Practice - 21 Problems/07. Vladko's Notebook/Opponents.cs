using System.Collections.Generic;

public class Opponents
{
    public string Color { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public List<string> OpponentsList { get; set; }
    public decimal Wins { get; set; }
    public decimal Losses { get; set; }

    public Opponents()
    {
        this.OpponentsList = new List<string>();
        this.Name = string.Empty;
        this.Age = 0;
        this.Color = string.Empty;
        this.Wins = 1;
        this.Losses = 1;
    }
}