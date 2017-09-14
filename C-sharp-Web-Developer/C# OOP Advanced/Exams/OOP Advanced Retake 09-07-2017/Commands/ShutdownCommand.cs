using System;
using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{

    public ShutdownCommand(IList<string> arguments, ICommandInterpreter commandInterpreter) : base(arguments, commandInterpreter)
    {
    }

    // имплементация на логиката трябва да стане тук
    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Produced: {this.commandInterpreter.ProviderController.TotalEnergyProduced}");
        sb.Append($"Total Mined Plumbus Ore: {this.commandInterpreter.HarvesterController.OreProduced}");

        return sb.ToString().Trim();
    }

}