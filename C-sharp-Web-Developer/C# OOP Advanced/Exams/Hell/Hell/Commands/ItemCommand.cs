using System.Collections.Generic;

public class ItemCommand : Command
{
    public ItemCommand(IList<string> argsList, IManager manager)
        : base(argsList, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.AddItemToHero(this.ArgsList);
    }
}