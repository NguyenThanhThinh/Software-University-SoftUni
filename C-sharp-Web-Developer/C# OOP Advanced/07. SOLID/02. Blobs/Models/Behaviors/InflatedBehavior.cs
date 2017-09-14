public class InflatedBehavior : Behavior
{
    public InflatedBehavior(IUnit blob)
        : base(blob)
    {
    }

    public override void Trigger()
    {
        this.HealthModifier = 50;
    }

    public override void OnTurn()
    {
        this.HealthModifier -= 10;
    }
}