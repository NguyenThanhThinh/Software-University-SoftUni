public class Barbarian : AbstractHero
{
    private const int StrengthDefault = 90;
    private const int AgilityDefault = 25;
    private const int IntelligenceDefault = 10;
    private const int HitPointsDefault = 350;
    private const int DamageDefault = 150;

    public Barbarian(string name)
        : base(name, StrengthDefault, AgilityDefault, IntelligenceDefault, HitPointsDefault, DamageDefault)
    {
    }
}