using System;

public class RoyalGuard : IAttackable
{
    public RoyalGuard(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public void OnKingUnderAttack(Object sender, EventArgs arg)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}