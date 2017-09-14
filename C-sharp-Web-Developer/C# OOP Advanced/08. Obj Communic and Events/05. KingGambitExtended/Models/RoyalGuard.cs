using System;

public class RoyalGuard : Soldier
{
    public const int RoyalHitCount = 3;

    public RoyalGuard(string name) 
        : base(name, RoyalHitCount)
    {
    }

    public override void OnKingUnderAttack(Object sender, EventArgs arg)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}