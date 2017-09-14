using System;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core;

namespace _04.BarrackWars_Commands_Strike_Back.Core.Commands
{
    public class Fight : Command

    {
        public Fight(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            //Console.WriteLine(Engine.sb);
            Environment.Exit(0);
            return string.Empty;
        }
    }
}