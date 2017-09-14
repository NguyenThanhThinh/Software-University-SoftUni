public class AggressiveBehavior : Behavior
{
    public AggressiveBehavior(IUnit blob)
        : base(blob)
    {
    }

    public override void Trigger()
    {
        this.DamageModifier = this.Unit.Damage;
    }

    public override void OnTurn()
    {
        this.DamageModifier -= 5;
    }
}