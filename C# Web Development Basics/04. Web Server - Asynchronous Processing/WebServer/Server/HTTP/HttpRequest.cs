namespace WebServer.Server.HTTP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Common;
    using Contracts;
    using Enums;
    using Exceptions;

    public class HttpRequest : IHttpRequest
    {
        private Dictionary<string, string> formData;
        private HttpHeaderCollection headerCollection;
        private string url;
        private string path;
        private Dictionary<string, string> queryParameters;
        private HttpRequestMethod requestMethod;
        private Dictionary<string, string> urlParameters;

        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, string>();
            this.HeaderCollection = new HttpHeaderCollection();
            this.QueryParameters = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }

        public Dictionary<string, string> FormData
        {
            get { return this.formData; }
            private set { this.formData = value; }
        }

        public HttpHeaderCollection HeaderCollection
        {
            get { return this.headerCollection; }
            private set { this.headerCollection = value; }
        }

        public string Url
        {
            get { return this.url; }
            private set { this.url = value; }
        }

        public string Path
        {
            get { return this.path; }
            private set { this.path = value; }

        }

        public Dictionary<string, string> QueryParameters
        {
            get { return this.queryParameters; }
            private set { this.queryParameters = value; }

        }

        public HttpRequestMethod RequestMethod
        {
            get { return this.requestMethod; }
            private set { this.requestMethod = value; }
        }

        public Dictionary<string, string> UrlParameters
        {
            get { return this.urlParameters; }
            private set { this.urlParameters = value; }

        }

        public void AddUrlParameter(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.UrlParameters[key] = value;
        }

        private void ParseRequest(string requestString)
        {
            string[] requestLines =
                requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            if (!requestLines.Any())
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            string[] requestLine = requestLines[0].Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());
            this.Url = requestLine[1];
            this.Path = this.Url
                .Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

            this.ParseHeaders(requestLines);
            this.ParseParamaters();

            if (this.RequestMethod == HttpRequestMethod.POST)
            {
                this.ParseQuery(requestLines[requestLines.Length - 1], this.FormData);
            }
        }

        private HttpRequestMethod ParseRequestMethod(string value)
        {
            HttpRequestMethod requestEnum;
            bool enumSuccess = Enum.TryParse(value, out requestEnum);

            if (!enumSuccess)
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            return requestEnum;
        }

        private void ParseHeaders(string[] requestLines)
        {
            int endIndex = Array.IndexOf(requestLines, String.Empty);

            for (int i = 1; i < endIndex; i++)
            {
                string[] headerArgs = requestLines[i].Split(new[] { ": " }, StringSplitOptions.None);

                if (headerArgs.Length != 2)
                {
                    BadRequestException.ThrowFromInvalidRequest();
                }
                string key = headerArgs[0];
                string value = headerArgs[1];

                HttpHeader currentHeader = new HttpHeader(key, value);
                this.HeaderCollection.Add(currentHeader);
            }

            if (!this.HeaderCollection.ContainsKey("Host"))
            {
                BadRequestException.ThrowFromInvalidRequest();
            }
        }

        private void ParseParamaters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            string query = this.Url.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries)[1];
            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, Dictionary<string, string> dict)
        {
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var queryPair in queryPairs)
            {
                string[] queryArgs = queryPair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                if (queryArgs.Length != 2)
                {
                    continue;
                }

                dict.Add(
                    WebUtility.UrlDecode(queryArgs[0]),
                    WebUtility.UrlDecode(queryArgs[1])
                );
            }
        }
    }
}