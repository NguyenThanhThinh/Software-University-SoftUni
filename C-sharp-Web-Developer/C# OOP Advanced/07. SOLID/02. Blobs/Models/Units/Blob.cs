
public class Blob : IUnit
{
    private long InitialDamage { get; set; }
    private string name;
    private long health;
    private long damage;
    private IBehaviorable behavior;
    private IAttackable attack;

    public Blob(string name, long health, long damage, IBehaviorable behavior, IAttackable attack)
    {
        this.Name = name;
        this.Health = health;
        this.Damage = damage;
        this.Behavior = behavior;
        this.Attack = attack;
        this.InitialDamage = damage;
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public long Health
    {
        get
        {
            return this.health += this.Behavior.HealthModifier;
        }
        protected set { this.health = value; }
    }

    public long Damage
    {
        get
        {
            return this.damage + this.Behavior.DamageModifier;
        }
        set
        {
            if (value < this.InitialDamage)
            {
                // TODO: Damage can't go below InitialDamage
            }
            this.Damage = value;
        }
    }

    public IBehaviorable Behavior
    {
        get
        {
            this.behavior.Trigger();
            return this.behavior;
        }
        protected set { this.behavior = value; }

    }

    public IAttackable Attack
    {
        get
        {
            this.behavior.Trigger();
            return this.attack;
        }
        protected set { this.attack = value; }

    }
}