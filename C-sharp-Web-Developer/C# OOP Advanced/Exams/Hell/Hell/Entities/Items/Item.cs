
public abstract class Item : IItem
{
    private string name;
    private string heroName;
    private long strengthBonus;
    private long agilityBonus;
    private long intelligenceBonus;
    private long hitPointsBonus;
    private long damageBonus;

    public Item(string name, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus)
    {
        this.Name = name;
        this.HeroName = heroName;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public long StrengthBonus
    {
        get { return this.strengthBonus; }
        protected set { this.strengthBonus = value; }

    }

    public long AgilityBonus
    {
        get { return this.agilityBonus; }
        protected set { this.agilityBonus = value; }

    }

    public long IntelligenceBonus
    {
        get { return this.intelligenceBonus; }
        protected set { this.intelligenceBonus = value; }

    }

    public long HitPointsBonus
    {
        get { return this.hitPointsBonus; }
        protected set { this.hitPointsBonus = value; }

    }

    public long DamageBonus
    {
        get { return this.damageBonus; }
        protected set { this.damageBonus = value; }

    }

    public string HeroName
    {
        get { return this.heroName; }
        set { this.heroName = value; }
    }
}