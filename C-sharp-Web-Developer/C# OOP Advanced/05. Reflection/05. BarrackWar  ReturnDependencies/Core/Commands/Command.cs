using Ninject;
using _03BarracksFactory.Contracts;

namespace _04.BarrackWars_Commands_Strike_Back.Core.Commands
{
    public abstract class Command : IExecutable
    {
        [Inject]
        private string[] data;

        public Command()
        {
        }

        public Command(string[] data)
        {
            this.Data = data;
        }

        public string[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public abstract string Execute();
    }
}