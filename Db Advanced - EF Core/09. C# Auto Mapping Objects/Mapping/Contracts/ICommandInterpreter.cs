namespace Mapping.Contracts
{
    public interface ICommandInterpreter
    {
        ICommand CommandParser(string commandName);
    }
}