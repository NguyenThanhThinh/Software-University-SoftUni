public class Wizard : AbstractHero
{
    private const int StrengthDefault = 25;
    private const int AgilityDefault = 25;
    private const int IntelligenceDefault = 100;
    private const int HitPointsDefault = 100;
    private const int DamageDefault = 250;

    public Wizard(string name)
        : base(name, StrengthDefault, AgilityDefault, IntelligenceDefault, HitPointsDefault, DamageDefault)
    {
    }
}