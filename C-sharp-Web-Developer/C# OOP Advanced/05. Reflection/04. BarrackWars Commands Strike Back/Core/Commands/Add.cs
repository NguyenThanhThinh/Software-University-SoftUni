using System;
using _03BarracksFactory.Contracts;

namespace _04.BarrackWars_Commands_Strike_Back.Core.Commands
{
    public class Add : Command
    {
        public Add(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}