public class Assassin : AbstractHero
{
    private const int StrengthDefault = 25;
    private const int AgilityDefault = 100;
    private const int IntelligenceDefault = 15;
    private const int HitPointsDefault = 150;
    private const int DamageDefault = 300;

    public Assassin(string name)
        : base(name, StrengthDefault, AgilityDefault, IntelligenceDefault, HitPointsDefault, DamageDefault)
    {
    }
}