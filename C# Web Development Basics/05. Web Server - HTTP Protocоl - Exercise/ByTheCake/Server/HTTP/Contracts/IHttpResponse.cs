namespace ByTheCake.Server.HTTP.Contracts
{
    public interface IHttpResponse
    {
        void AddHeader(string location, string redirectUrl);
    }
}