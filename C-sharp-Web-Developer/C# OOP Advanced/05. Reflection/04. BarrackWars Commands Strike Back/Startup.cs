using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core;
using _03BarracksFactory.Core.Factories;
using _03BarracksFactory.Data;

namespace _04.BarrackWars_Commands_Strike_Back
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