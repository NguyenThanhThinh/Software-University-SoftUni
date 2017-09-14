public class PutridFart : Attack
{

    public PutridFart(IUnit unit)
        : base(unit)
    {
    }

    public override void Trigger()
    {
        this.DamageModifier = 0;
    }
}