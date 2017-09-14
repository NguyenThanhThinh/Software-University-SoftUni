using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core;
using _03BarracksFactory.Core.Factories;
using _03BarracksFactory.Data;

namespace _05.BarrackWar__ReturnDependencies
{
    public class Startup
    {
        public static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(unitFactory, repository);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}