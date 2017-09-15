using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OverAllSKillMultiplier = 3.5d;
    private const string Gun = "Gun";
    private const string AutomaticMachine = "AutomaticMachine";
    private const string Helmet = "Helmet";
    private const string MachineGun = "MachineGun";
    private const string RPG = "RPG";
    private const string Knife = "Knife";
    private const string NightVision = "NightVision";

    private static readonly List<string> WeaponsAllowedReadOnly = new List<string>
    {
        Gun,
        AutomaticMachine,
        Helmet,
        MachineGun,
        RPG,
        Knife,
        NightVision
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