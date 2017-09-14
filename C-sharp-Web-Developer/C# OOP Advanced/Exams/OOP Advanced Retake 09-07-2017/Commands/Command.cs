using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected IList<string> arguments;
    protected ICommandInterpreter commandInterpreter;

    protected Command(IList<string> arguments, ICommandInterpreter commandInterpreter)
    {
        this.Arguments = arguments;
        this.commandInterpreter = commandInterpreter;
    }

    public IList<string> Arguments
    {
        get { return this.arguments; }
        set { this.arguments = value; }
    }

    public abstract string Execute();
}