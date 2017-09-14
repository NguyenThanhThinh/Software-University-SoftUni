using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite
{
    public class Repairs : IRepairable
    {
        private string name;
        private int workedHours;

        public Repairs(string name, int workedHours)
        {
            this.Name = name;
            this.WorkedHours = workedHours;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int WorkedHours
        {
            get { return workedHours; }
            set { workedHours = value; }
        }

        public override string ToString()
        {
            return String.Format($"Part Name: {this.Name} Hours Worked: {this.WorkedHours}");
        }
    }
}
