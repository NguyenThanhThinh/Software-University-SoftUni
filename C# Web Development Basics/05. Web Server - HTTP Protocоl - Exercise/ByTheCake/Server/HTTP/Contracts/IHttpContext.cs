namespace ByTheCake.Server.HTTP.Contracts
{
    public interface IHttpContext
    {
        HttpRequest Request { get; }
    }
}