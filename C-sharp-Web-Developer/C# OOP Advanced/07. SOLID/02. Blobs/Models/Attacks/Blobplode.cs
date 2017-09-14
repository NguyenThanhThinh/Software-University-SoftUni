public class Blobplode : Attack
{
    public Blobplode(IUnit unit)
        : base(unit)
    {
    }

    public override void Trigger()
    {
        this.HealthModifier /= 2;
        this.DamageModifier *= 2;
    }
}