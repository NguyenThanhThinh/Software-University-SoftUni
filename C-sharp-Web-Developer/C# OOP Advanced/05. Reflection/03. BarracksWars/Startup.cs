using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core;
using _03BarracksFactory.Core.Factories;
using _03BarracksFactory.Data;

namespace _03.BarracksWars
{
    public class Startup
    {
        public static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}