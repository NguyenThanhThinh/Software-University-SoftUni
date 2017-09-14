using System.Collections.Generic;

namespace _10.Inferno_Infinity.Repository
{
    public class Repository
    {
        private static Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();

        public static Dictionary<string, Weapon> Weapons
        {
            get { return weapons; }
            protected set { weapons = value; }
        }

        public static void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon.Name, weapon);
        }
    }
}