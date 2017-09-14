using System;
using System.Collections.Generic;
using System.Text;

public class DayCommand : Command
{
    public DayCommand(IList<string> arguments, ICommandInterpreter commandInterpreter)
        : base(arguments, commandInterpreter)
    {
    }

    // имплементация на логиката трябва да стане тук
    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.commandInterpreter.ProviderController.Produce());
        sb.AppendLine(this.commandInterpreter.HarvesterController.Produce());

        return sb.ToString().Trim();
    }


}