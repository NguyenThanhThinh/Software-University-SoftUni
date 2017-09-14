namespace _06.Twiter
{
    public interface IClient
    {
        void WriteToConsole();
        ITweetable Tweet { get; }
    }
}