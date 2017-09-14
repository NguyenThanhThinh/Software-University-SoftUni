using System;

public delegate void KingUnderAttackEventHandler(object sender, EventArgs args);

public class King
{
    public event KingUnderAttackEventHandler UnderAttack;

    public King(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public void RespondToAttack()
    {
        Console.WriteLine("King {0} is under attack!", this.Name);
        OnKingAttacked(new EventArgs());
    }

    protected void OnKingAttacked(EventArgs args)
    {
        if (UnderAttack != null)
        {
            UnderAttack(this, args);
        }
    }

    public void OnSoldierDeath(object sender, SoldierDeathEventArgs args)
    {
        this.UnderAttack -= args.RespondMethod;
    }
}