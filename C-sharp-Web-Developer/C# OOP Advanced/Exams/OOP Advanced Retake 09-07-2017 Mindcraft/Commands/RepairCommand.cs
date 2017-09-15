using System.Collections.Generic;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> arguments, ICommandInterpreter commandInterpreter)
        : base(arguments, commandInterpreter)
    {
    }

    public override string Execute()
    {
        double repairValue = double.Parse(this.Arguments[0]);

        return this.commandInterpreter.ProviderController.Repair(repairValue).Trim();
    }
}