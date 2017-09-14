using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TeamWork_Project
{
    class Team
    {
        private string name = "";
        private string creator = "";
        private List<string> members = new List<string>();

        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public Team()
        {
            this.Members = new List<string>();
        }
    }
}
