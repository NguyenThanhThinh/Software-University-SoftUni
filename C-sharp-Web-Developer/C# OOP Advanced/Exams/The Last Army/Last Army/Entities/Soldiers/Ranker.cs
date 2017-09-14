using System.Collections.Generic;

public class Ranker : Soldier
{
    private static readonly List<string> WeaponsAllowedReadOnly = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "Helmet",
    };

    private const double OverAllSKillMultiplier = 1.5d;

    public Ranker(string name, int age, double experience, double endurance)
            : base(name, age, experience, endurance)
    {
        InitilizeWeapons();
    }

    protected override void InitilizeWeapons()
    {
        foreach (var weapon in WeaponsAllowedReadOnly)
        {
            this.Weapons[weapon] = null;
        }
    }

    public override double OverallSkill
    {
        get { return (this.Age + this.Experience) * OverAllSKillMultiplier; }
    }
}