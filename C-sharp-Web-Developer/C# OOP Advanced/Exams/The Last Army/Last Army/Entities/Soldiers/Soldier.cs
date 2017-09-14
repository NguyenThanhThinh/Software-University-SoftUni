using System;
using System.Collections.Generic;

public abstract class Soldier : ISoldier
{
    private string name;
    private int age;
    private double experience;
    private double endurance;
    private IDictionary<string, IAmmunition> weapons;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();
    }

    protected abstract void InitilizeWeapons();

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        protected set { this.age = value; }
    }

    public double Experience
    {
        get { return this.experience; }
        protected set { this.experience = value; }
    }

    public double Endurance
    {
        get { return this.endurance; }
        protected set
        {
            if (value > 100)
            {
                value = 100;
            }
            this.endurance = value;
        }
    }

    public abstract double OverallSkill { get; }

    public IDictionary<string, IAmmunition> Weapons
    {
        get { return this.weapons; }
        protected set { this.weapons = value; }
    }

    public virtual void Regenerate()
    {
        this.Endurance += 10 + this.Age;
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired || !this.CheckCurrentWeaponsWearLevel())
        {
            return false;
        }
        return true;
    }

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;

        foreach (var weapon in this.Weapons.Values)
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);
        }

        this.Experience += mission.EnduranceRequired;
    }

    protected bool CheckCurrentWeaponsWearLevel()
    {
        foreach (var weapon in this.Weapons)
        {
            if (weapon.Value.WearLevel <= 0)
            {
                return false;
            }
        }

        return true;
    }

    public override string ToString()
    {
        return String.Format($"{this.Name} - {this.OverallSkill}");
    }
}