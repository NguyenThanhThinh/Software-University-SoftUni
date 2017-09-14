using _03BarracksFactory.Contracts;

namespace _04.BarrackWars_Commands_Strike_Back.Core.Commands
{
    public class Report : Command
    {
        public Report(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}