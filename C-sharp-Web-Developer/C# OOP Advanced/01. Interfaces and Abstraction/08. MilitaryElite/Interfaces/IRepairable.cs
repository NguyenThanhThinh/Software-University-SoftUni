using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite
{
    public interface IRepairable
    {
        string Name { get; set; }
        int WorkedHours { get; set; }
    }
}
