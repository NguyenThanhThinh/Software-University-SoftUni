using System;

public class SoldierDeathEventArgs : EventArgs
{
    public SoldierDeathEventArgs(string name, KingUnderAttackEventHandler respondMethod)
    {
        this.Name = name;
        this.RespondMethod = respondMethod;
    }

    public string Name { get; private set; }

    public KingUnderAttackEventHandler RespondMethod { get; private set; }
}