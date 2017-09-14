using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        protected SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }
            
        public string Corps
        {
            get { return corps; }
            set
            {
                if (!value.Equals("Airforces") && !value.Equals("Marines"))
                {
                    throw new ArgumentException("Invalid corps time");
                }
                corps = value;
            }
        }

        public override string ToString()
        {
            return string.Format($"{base.ToString()}{Environment.NewLine}Corps: {this.Corps}");
        }
    }
}
