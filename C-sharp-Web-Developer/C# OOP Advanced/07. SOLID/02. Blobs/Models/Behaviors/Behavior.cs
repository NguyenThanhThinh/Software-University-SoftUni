
using System;

public delegate void EventHandlerBehavior(object sender, EventArgs arg);

public abstract class Behavior : IBehaviorable
{
    private long damageModifier;
    private long healthModifier;
    protected IUnit Unit { get; set; }

    public Behavior(IUnit blob)
    {
        this.Unit = blob;
    }

    public abstract void Trigger();

    public abstract void OnTurn();

    public long DamageModifier
    {
        get { return this.damageModifier; }
        set { this.damageModifier = value; }
    }

    public long HealthModifier
    {
        get { return this.healthModifier; }
        set { this.healthModifier = value; }
    }
}