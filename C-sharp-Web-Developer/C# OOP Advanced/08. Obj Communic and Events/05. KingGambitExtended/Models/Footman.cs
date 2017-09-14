using System;

public class Footman : Soldier
{
    public const int FootmanHits = 2;

    public Footman(string name) 
        : base(name, FootmanHits)
    {
    }

    public override void OnKingUnderAttack(object sender, EventArgs arg)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}