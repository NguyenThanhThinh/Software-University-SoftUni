namespace _10.Inferno_Infinity
{
    // Interfaces are quite of unnecessary for this task, but I just wanted to use some
    public interface IWeapon
    {
        string Name { get; }
        int DefaultMaxDamage { get; }
        int DefaultMinDamage { get; }
        int NumberOfSockets { get; }
        string Rarity { get; }
    }
}