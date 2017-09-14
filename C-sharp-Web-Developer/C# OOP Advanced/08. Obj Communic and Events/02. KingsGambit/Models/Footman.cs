using System;

public class Footman : IAttackable
{
    public Footman(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public void OnKingUnderAttack(Object sender, EventArgs arg)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}