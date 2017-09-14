using System.Collections.Generic;

public abstract class Command : ICommand
{
    private IManager manager;
    private IList<string> argsList;

    protected Command(IList<string> argsList, IManager manager)
    {
        this.Manager = manager;
        this.ArgsList = argsList;
    }

    public IManager Manager
    {
        get { return this.manager; }
        protected set { this.manager = value; }
    }

    public IList<string> ArgsList
    {
        get { return this.argsList; }
        protected set { this.argsList = value; }
    }

    public abstract string Execute();
}