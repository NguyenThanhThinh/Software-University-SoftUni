using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite
{
    public class Engineer : SpecialisedSoldier
    {
        private List<Repairs> repairs;

        public Engineer(int id, string firstName, string lastName, double salary, string corps, List<Repairs> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public List<Repairs> Repairs
        {
            get { return repairs; }
            set { repairs = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString())
                .Append(Environment.NewLine)
                .Append("Repairs:");

            foreach (var item in this.Repairs)
            {
                sb.Append(Environment.NewLine)
                    .Append($"  {item.ToString()}");
            }
            return sb.ToString();
        }
    }
}
