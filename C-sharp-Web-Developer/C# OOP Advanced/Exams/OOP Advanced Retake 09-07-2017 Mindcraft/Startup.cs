using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IEnergyRepository energyRepository = new EnergyRepository();
        List<IHarvester> harvesters = new List<IHarvester>();
        IHarvesterController harvesterController = new HarvesterController(harvesterFactory, energyRepository, harvesters);
        IProviderController providerController = new ProviderController(energyRepository);
        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);
        IWriter writer = new ConsoleWriter();
        IReader reader = new ConsoleReader();

        Engine engine = new Engine(commandInterpreter, reader, writer);
        engine.Run();
    }
}