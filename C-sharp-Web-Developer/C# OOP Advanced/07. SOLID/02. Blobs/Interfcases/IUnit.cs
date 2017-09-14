public interface IUnit
{
    string Name { get; }
    long Health { get; }
    long Damage { get; set; }

    IBehaviorable Behavior { get; }
    IAttackable Attack { get; }
}