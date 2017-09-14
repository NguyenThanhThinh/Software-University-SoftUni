
class LastArmyMain
{
    static void Main()
    {
        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse();
        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        IMissionFactory missionFactory = new MissionFactory();
        ISoldierFactory soldierFactory = new SoldierFactory();
        IReader consoleReader = new ConsoleReader();
        IWriter consoleWriteLine = new ConsoleWriter();
        MissionController missionController = new MissionController(army, wareHouse);
        GameController gameController = new GameController(wareHouse, army, missionController, soldierFactory, ammunitionFactory, missionFactory);
        Engine engine = new Engine(gameController, consoleReader, consoleWriteLine);

        engine.Run();
    }
}