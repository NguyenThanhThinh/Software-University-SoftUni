using System;
using System.Linq;
using _11.Custom_Attribute;

namespace _10.Inferno_Infinity
{
    [Custom(author: "Pesho", revision: 3, description: "Used for C# OOP Advanced Course - Enumerations and Attributes."
        , reviewers: "Pesho, Svetlio")]
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int defaultDefaultMaxDamage;
        private int defaultDefaultMinDamage;
        private int modifiedMaxDamage;
        private int modifiedMinDamage;
        private int numberOfSockets;
        private string rarity;
        private Gem[] gems;

        public Weapon(string name, string rarity, int defaultMinDamage, int defaultMaxDamage, int numberOfSockets)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.DefaultMinDamage = defaultMinDamage;
            this.DefaultMaxDamage = defaultMaxDamage;
            this.NumberOfSockets = numberOfSockets;
            this.Gems = new Gem[this.NumberOfSockets];
            ModifyMinimumDamage();
            ModifyMaximumDamage();
        }

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        public int DefaultMaxDamage
        {
            get { return defaultDefaultMaxDamage; }
            protected set { defaultDefaultMaxDamage = value; }
        }

        public int DefaultMinDamage
        {
            get { return defaultDefaultMinDamage; }
            protected set { defaultDefaultMinDamage = value; }
        }

        public int NumberOfSockets
        {
            get { return numberOfSockets; }
            protected set { numberOfSockets = value; }
        }

        public string Rarity
        {
            get { return rarity; }
            protected set { rarity = value; }
        }

        public Gem[] Gems
        {
            get { return gems; }
            protected set { gems = value; }
        }

        public int ModifiedMaxDamage
        {
            get { return modifiedMaxDamage; }
            protected set { modifiedMaxDamage = value; }
        }

        public int ModifiedMinDamage
        {
            get { return modifiedMinDamage; }
            protected set { modifiedMinDamage = value; }
        }

        protected void ModifyMinimumDamage()
        {
            this.DefaultMinDamage *= TakeMultiplierByRariry(this.Rarity);
        }

        protected void ModifyMaximumDamage()
        {
            this.DefaultMaxDamage *= TakeMultiplierByRariry(this.Rarity);
        }

        protected virtual int TakeMultiplierByRariry(string rarity)
        {
            switch (this.Rarity)
            {
                case "Common":
                    return 1;
                case "Uncommon":
                    return 2;
                case "Rare":
                    return 3;
                case "Epic":
                    return 5;
            }

            return 0;
        }

        public virtual void ModifyDamageOnWeaponsWithGems()
        {
            int totalStrength = this.Gems.Where(g => !(g is null)).Sum(s => s.Strength);
            int totalAgility = this.Gems.Where(g => !(g is null)).Sum(s => s.Agility);

            this.ModifiedMinDamage = this.DefaultMinDamage + (totalStrength * 2) + totalAgility;
            this.ModifiedMaxDamage = this.DefaultMaxDamage + (totalStrength * 3) + (totalAgility * 4);
        }

        public virtual void AddGemInSocket(int index, Gem gem)
        {
            if (index >= 0 && index < this.Gems.Length)
            {
                this.Gems[index] = gem;
            }
        }

        public virtual void RemoveGemFromSocket(int index)
        {
            if (index >= 0 && index < this.Gems.Length)
            {
                this.Gems[index] = null;
            }
        }

        public override string ToString()
        {
            ModifyDamageOnWeaponsWithGems();
            return String.Format($"{this.Name}: {this.ModifiedMinDamage}-{this.ModifiedMaxDamage} Damage," +
                                 $" +{this.Gems.Where(g => !(g is null)).Sum(s => s.Strength)} Strength, " +
                                 $"+{this.Gems.Where(g => !(g is null)).Sum(s => s.Agility)} Agility, " +
                                 $"+{this.Gems.Where(g => !(g is null)).Sum(s => s.Vitality)} Vitality");
        }
    }
}