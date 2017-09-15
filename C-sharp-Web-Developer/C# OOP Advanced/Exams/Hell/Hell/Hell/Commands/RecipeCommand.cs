using System.Collections.Generic;

public class RecipeCommand : Command
{
    public RecipeCommand(IList<string> argsList, IManager manager)
        : base(argsList, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.AddItemToHero(this.ArgsList);
    }
}