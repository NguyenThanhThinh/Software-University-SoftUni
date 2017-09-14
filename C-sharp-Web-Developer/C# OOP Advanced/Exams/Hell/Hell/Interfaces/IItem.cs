using System.Collections.Generic;

public interface IItem
{
    string Name { get; }
    string HeroName { get; }
    long StrengthBonus { get; }
    long AgilityBonus { get; }
    long IntelligenceBonus { get; }
    long HitPointsBonus { get; }
    long DamageBonus { get; }
}