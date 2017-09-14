using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        private double salary;

        public Private(int id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public override string ToString()
        {
            return String.Format($"{base.ToString()} Salary: {this.Salary:F2}");
        }
    }
}
