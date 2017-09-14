using System;
using _03BarracksFactory.Contracts;
using _05.BarrackWar__ReturnDependencies;

namespace _04.BarrackWars_Commands_Strike_Back.Core.Commands
{
    public class Retire : Command
    {
        [Inject]
        private IRepository repository;

        public Retire(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            this.Repository.RemoveUnit(unitType);
            return String.Format($"{unitType} retired!");
        }
    }
}