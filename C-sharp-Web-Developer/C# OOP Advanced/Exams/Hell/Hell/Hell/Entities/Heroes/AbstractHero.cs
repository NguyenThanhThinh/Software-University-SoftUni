using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
    {
        this.Name = name;
        this.Strength = strength;
        this.Agility = agility;
        this.Intelligence = intelligence;
        this.HitPoints = hitPoints;
        this.Damage = damage;
        this.Inventory = new HeroInventory();
    }

    public string Name { get; private set; }

    public long Strength
    {
        get { return this.strength + this.Inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.Inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.Inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.Inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.Inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    public ICollection<IItem> Items
    {
        get { return GetItems(); }
    }

    private ICollection<IItem> GetItems()
    {
        Type heroType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(this.GetType().Name));

        if (heroType != null)
        {
            var inventoryProperty = (IInventory)heroType.GetProperties().FirstOrDefault(p => p.Name.Equals("Inventory")).GetValue(this, null);
            var inventoryClass = Activator.CreateInstance(inventoryProperty.GetType());
            Type inventoryType = inventoryClass.GetType();

            FieldInfo inventoryItemsField = inventoryType.GetField("commonItems", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, IItem> items = (Dictionary<string, IItem>)inventoryItemsField.GetValue(this.inventory);

            return items.Select(x => x.Value).ToList();
        }

        return null;
    }

    public IInventory Inventory
    {
        get { return this.inventory; }
        set { this.inventory = value; }
    }

    public void AddRecipe(IRecipe item)
    {
        this.Inventory.AddRecipeItem(item);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}")
            .AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}")
            .AppendLine($"Strength: {this.Strength}")
            .AppendLine($"Agility: {this.Agility}")
            .AppendLine($"Intelligence: {this.Intelligence}");

        if (this.Items.Count == 0)
        {
            sb.AppendLine("Items: None");
        }
        else
        {
            sb.AppendLine($"Items:");

            var currentItems = this.Items;

            foreach (var item in currentItems)
            {
                sb.AppendLine($"###Item: {item.Name}");
                sb.AppendLine($"###+{item.StrengthBonus} Strength")
                    .AppendLine($"###+{item.AgilityBonus} Agility")
                    .AppendLine($"###+{item.IntelligenceBonus} Intelligence")
                    .AppendLine($"###+{item.HitPointsBonus} HitPoints")
                    .AppendLine($"###+{item.DamageBonus} Damage");
            }
        }

        return sb.ToString();
    }
}