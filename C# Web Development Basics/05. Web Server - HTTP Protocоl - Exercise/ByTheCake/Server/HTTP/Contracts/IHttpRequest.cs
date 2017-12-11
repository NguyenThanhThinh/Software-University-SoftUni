namespace ByTheCake.Server.HTTP.Contracts
{
    using System.Collections.Generic;
    using Enums;

    public interface IHttpRequest
    {
        Dictionary<string, string> FormData { get; }

        HttpHeaderCollection HeaderCollection { get; }

        string Url { get; }

        string Path { get; }

        Dictionary<string, string> QuearyParameters { get; }

        HttpRequestMethod RequestMethod { get; }

        Dictionary<string, string> UrlParameters { get; }

        void AddUrlParameter(string key, string value);
    }
}