using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite
{
    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private List<Private> privates;

        public List<Private> Privates
        {
            get { return privates; }
            set { privates = value; }
        }

        public LeutenantGeneral(int id, string firstName, string lastName, double salary, List<Private> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString())
                .Append(Environment.NewLine)
                .Append("Privates:");

            foreach (var item in this.Privates)
            {
                sb.Append(Environment.NewLine)
                  .Append($"  {item.ToString()}");
            }
            return sb.ToString();
        }
    }
}
