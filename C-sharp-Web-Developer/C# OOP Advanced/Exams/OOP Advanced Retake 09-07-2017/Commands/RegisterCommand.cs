using System;
using System.Collections.Generic;

public class RegisterCommand : Command
{
    private const string Harvester = "Harvester";
    private const string Provider = "Provider";

    public RegisterCommand(IList<string> arguments, ICommandInterpreter commandInterpreter)
        : base(arguments, commandInterpreter)
    {
    }

    public override string Execute()
    {
        var type = this.Arguments[0];
        this.Arguments.RemoveAt(0);
        try
        {
            if (type.Equals(Harvester))
            {
                return this.commandInterpreter.HarvesterController.Register(this.Arguments).Trim();
            }
            if (type.Equals(Provider))
            {
                return this.commandInterpreter.ProviderController.Register(this.Arguments).Trim();

            }
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }

        return String.Empty;
    }
}