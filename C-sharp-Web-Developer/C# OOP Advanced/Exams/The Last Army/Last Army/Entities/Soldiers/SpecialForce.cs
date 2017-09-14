using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OverAllSKillMultiplier = 3.5d;

    private static readonly List<string> WeaponsAllowedReadOnly = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "RPG",
        "Helmet",
        "Knife",
        "NightVision"
    };

    public SpecialForce(string name, int age, double experience, double endurance)
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

    public override void Regenerate()
    {
        this.Endurance += 30 + this.Age;
    }
}