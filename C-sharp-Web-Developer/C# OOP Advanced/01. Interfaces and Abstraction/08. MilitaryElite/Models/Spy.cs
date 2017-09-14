using System;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        private string codeNumber;

        public Spy(int id, string firstName, string lastName, string codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public string CodeNumber
        {
            get { return codeNumber; }
            set { codeNumber = value; }
        }

        public override string ToString()
        {
            return string.Format($"{base.ToString()}{Environment.NewLine}Code Number: {this.CodeNumber}");
        }
    }
}