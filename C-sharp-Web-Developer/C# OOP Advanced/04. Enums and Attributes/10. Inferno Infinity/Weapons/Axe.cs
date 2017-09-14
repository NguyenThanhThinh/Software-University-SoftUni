using System;
using System.Collections.Generic;
using System.Linq;
namespace _10.Inferno_Infinity
{
    public class Axe : Weapon
    {
        public Axe(string name, string rarity) 
            : base(name, rarity, 5, 10, 4)
        {
        }
    }
}