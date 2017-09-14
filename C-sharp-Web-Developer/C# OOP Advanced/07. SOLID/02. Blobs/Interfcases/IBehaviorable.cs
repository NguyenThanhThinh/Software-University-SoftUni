public interface IBehaviorable
{
    void Trigger();
    void OnTurn();
    long DamageModifier { get; set; }
    long HealthModifier { get; set; }
}