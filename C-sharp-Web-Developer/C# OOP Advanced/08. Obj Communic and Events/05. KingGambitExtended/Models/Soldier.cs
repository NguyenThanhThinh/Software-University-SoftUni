using System;

public delegate void SoldierDeathEventHandler(object sender, SoldierDeathEventArgs args);

public abstract class Soldier : IAttackable
{
    public Soldier(string name, int hitCount)
    {
        this.Name = name;
        this.HitCount = hitCount;
    }

    public event SoldierDeathEventHandler SoldierDeath;

    public string Name { get; private set; }

    public int HitCount { get; set; }

    protected virtual void OnSoldierDeath(SoldierDeathEventArgs args)
    {
        if (SoldierDeath != null)
        {
            SoldierDeath(this, args);
        }
    }

    public void RespondToAttack()
    {
        this.HitCount--;
        if (this.HitCount == 0)
        {
            OnSoldierDeath(new SoldierDeathEventArgs(this.Name, OnKingUnderAttack));
        }
    }

    public abstract void OnKingUnderAttack(Object sender, EventArgs arg);
}