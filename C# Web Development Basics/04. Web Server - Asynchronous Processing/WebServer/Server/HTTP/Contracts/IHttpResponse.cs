namespace WebServer.Server.HTTP.Contracts
{
    public interface IHttpResponse
    {
        void AddHeader(string location, string redirectUrl);
    }
}