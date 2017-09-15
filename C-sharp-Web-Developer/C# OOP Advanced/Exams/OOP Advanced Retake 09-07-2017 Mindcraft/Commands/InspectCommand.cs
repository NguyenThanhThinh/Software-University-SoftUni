using System;
using System.Collections.Generic;
using System.Text;

public class InspectCommand : Command
{

    public InspectCommand(IList<string> arguments, ICommandInterpreter commandInterpreter)
        : base(arguments, commandInterpreter)
    {
    }

    public override string Execute()
    {
        var id = int.Parse(arguments[0]);
        var sb = new StringBuilder();
        bool check = false;

        foreach (var entity in this.commandInterpreter.ProviderController.Entities)
        {
            if (id == entity.ID)
            {
                sb.AppendLine(entity.ToString());
                check = true;
            }
        }

        foreach (var entity in this.commandInterpreter.HarvesterController.Entities)
        {
            if (id == entity.ID)
            {
                sb.AppendLine(entity.ToString());
                check = true;
            }
        }

        if (!check)
        {
            sb.AppendLine(String.Format(Constants.NoIdFOund, id));
        }

        return sb.ToString().Trim();
    }
}