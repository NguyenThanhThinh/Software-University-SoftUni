using System.Collections.Generic;

public interface IHero
{
    IInventory Inventory { get; }
    string Name { get; }
    long Strength { get; }
    long Agility { get; }
    long Intelligence { get; }
    long HitPoints { get; }
    long Damage { get; }
    ICollection<IItem> Items { get; }
    long PrimaryStats { get; }
    long SecondaryStats { get; }
}