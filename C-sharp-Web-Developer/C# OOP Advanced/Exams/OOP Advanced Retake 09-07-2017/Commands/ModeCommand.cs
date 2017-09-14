using System;
using System.Collections.Generic;

public class ModeCommand : Command
{

    public ModeCommand(IList<string> arguments, ICommandInterpreter commandInterpreter) : base(arguments, commandInterpreter)
    {

    }

    public override string Execute()
    {
        var mode = arguments[0];

        return this.commandInterpreter.HarvesterController.ChangeMode(mode).Trim();
    }


}