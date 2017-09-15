using System.Collections.Generic;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> argsList, IManager manager)
        : base(argsList, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.Inspect(this.ArgsList);
    }
}