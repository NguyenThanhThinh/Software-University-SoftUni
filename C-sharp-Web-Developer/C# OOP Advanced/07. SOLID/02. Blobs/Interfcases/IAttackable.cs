public interface IAttackable
{
    long DamageModifier { get; set; }
    long HealthModifier { get; set; }
    void Trigger();
}