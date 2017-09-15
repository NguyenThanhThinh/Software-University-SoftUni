using System.Collections.Generic;

public interface IWareHouse
{
    IDictionary<string, IAmmunition> Weapons { get; }

    IDictionary<string, int> WeaponsCounter { get; }

    void EquipArmy(IArmy army);

    bool EquipSoldier(ISoldier soldier);

    void AddAmmunition(IAmmunition ammunition, int numberOfAmmunitions);
}