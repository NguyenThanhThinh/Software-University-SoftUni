using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite
{
    class Commando : SpecialisedSoldier, ICommando
    {
        private string codeName;
        private List<Mission> missions;

        public Commando(int id, string firstName, string lastName, double salary, string corps,
            List<Mission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public string CodeName
        {
            get { return codeName; }
            set { codeName = value; }
        }

        public List<Mission> Missions
        {
            get { return missions; }
            set { missions = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString())
                .Append(Environment.NewLine)
                .Append("Missions:");

            foreach (var mission in this.Missions)
            {
                sb.Append(Environment.NewLine)
                    .Append($"  {mission.ToString()}");
            }
            return sb.ToString();
        }
    }
}