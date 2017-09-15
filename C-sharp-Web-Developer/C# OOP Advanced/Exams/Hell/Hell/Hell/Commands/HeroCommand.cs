using System.Collections.Generic;

public class HeroCommand : Command
{
    public HeroCommand(IList<string> argsList, IManager manager)
        : base(argsList, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.AddHero(this.ArgsList);
    }
}