using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IDictionary<string, IAmmunition> weapons;
    private IDictionary<string, int> weaponsCounter;

    public WareHouse()
    {
        this.weapons = new Dictionary<string, IAmmunition>();
        this.WeaponsCounter = new Dictionary<string, int>();
    }

    public IDictionary<string, IAmmunition> Weapons
    {
        get { return this.weapons; }
        protected set { this.weapons = value; }
    }

    public IDictionary<string, int> WeaponsCounter
    {
        get { return this.weaponsCounter; }
        protected set { this.weaponsCounter = value; }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.ReplaceSoldierWornWeapons(soldier);
        }
    }

    public bool EquipSoldier(ISoldier soldier)
    {
        List<string> soldierWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();

        if (!this.GiveWeapon(soldier, soldierWeapons))
        {
            return false;
        }

        return true;
    }

    private bool GiveWeapon(ISoldier soldier, List<string> listOfWeapons)
    {
        foreach (string currentWeapon in listOfWeapons)
        {
            if (!this.Weapons.ContainsKey(currentWeapon) || this.WeaponsCounter[currentWeapon] <= 0)
            {
                return false;
            }
            soldier.Weapons[currentWeapon] = this.Weapons[currentWeapon];
            this.WeaponsCounter[currentWeapon]--;
        }
        return true;
    }

    private bool ReplaceSoldierWornWeapons(ISoldier soldier)
    {
        List<string> soldierNeededReplaceWeapons = soldier.Weapons.Where(w => w.Value.WearLevel <= 0).Select(w => w.Key).ToList();

        if (!this.GiveWeapon(soldier, soldierNeededReplaceWeapons))
        {
            return false;
        }

        return true;
    }

    public void AddAmmunition(IAmmunition ammunition, int numberOfAmmunitions)
    {
        this.Weapons[ammunition.Name] = ammunition;

        if (!this.WeaponsCounter.ContainsKey(ammunition.Name))
        {
            this.WeaponsCounter[ammunition.Name] = 0;
        }

        this.WeaponsCounter[ammunition.Name] += numberOfAmmunitions;
    }
}