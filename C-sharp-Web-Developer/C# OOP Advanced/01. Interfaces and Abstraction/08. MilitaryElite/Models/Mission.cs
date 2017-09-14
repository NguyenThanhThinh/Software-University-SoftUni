using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite
{
    public class Mission : IMission
    {
        private string codeName;
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName
        {
            get { return codeName; }
            set { codeName = value; }
        }

        public string State
        {
            get { return state; }
            set
            {
                if (!value.Equals("Finished") && !value.Equals("inProgress"))
                {
                    throw new ArgumentException("Invalid state type");
                }
                state = value;
            }
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return String.Format($"Code Name: {this.CodeName} State: {this.State}");
        }
    }
}
