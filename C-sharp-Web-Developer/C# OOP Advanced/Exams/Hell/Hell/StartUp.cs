using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        IInputReader reader = new InputReader();
        IOutputWriter writer = new OutputWriter();
        Dictionary<string, IHero> heroes = new Dictionary<string, IHero>();
        IManager heroManager = new HeroManager(heroes);

        Engine engine = new Engine(reader, writer, heroManager);
        engine.Run();
    }
}