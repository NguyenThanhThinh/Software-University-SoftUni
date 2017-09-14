public abstract class Attack : IAttackable
{
    private long damageModifier;
    private long healthModifier;

    protected Attack(IUnit unit)
    {
        this.Unit = unit;
    }

    protected IUnit Unit { get; set; }

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

    public abstract void Trigger();
}