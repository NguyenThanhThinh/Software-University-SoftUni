using System;
using _03BarracksFactory.Contracts;

namespace _04.BarrackWars_Commands_Strike_Back.Core.Commands
{
    public class Retire : Command
    {
        public Retire(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];

            try
            {
                this.Repository.RemoveUnit(unitType);
                return String.Format($"{unitType} retired!");
            }
            catch (ArgumentException arg)
            {
                return arg.Message;
            }
        }
    }
}