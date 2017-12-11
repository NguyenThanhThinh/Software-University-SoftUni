namespace Mapping.Contracts
{
    public interface ICommand
    {
        string Execute(params string[] tokens);
    }
}