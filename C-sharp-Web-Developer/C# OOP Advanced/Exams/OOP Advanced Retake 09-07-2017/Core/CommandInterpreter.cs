
using System;
using System.Collections.Generic;

public class CommandInterpreter : ICommandInterpreter
{

    private const string CommandSuffix = "Command";

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public IHarvesterController HarvesterController
    {
        get { return this.harvesterController; }
    }

    public IProviderController ProviderController
    {
        get { return this.providerController; }
    }

    public string ProcessCommand(IList<string> args)
    {

        var command = args[0];

        args.RemoveAt(0);

        Type commandType = Type.GetType(command + CommandSuffix);
        var constructor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(ICommandInterpreter) });
        ICommand cmd = (ICommand)constructor.Invoke(new object[] { args, this });

        return cmd.Execute();
    }
}