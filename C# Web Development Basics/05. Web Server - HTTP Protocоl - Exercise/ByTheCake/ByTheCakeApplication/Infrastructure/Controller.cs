namespace ByTheCake.ByTheCakeApplication.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Server.Enums;
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;
    using Views;

    public abstract class Controller
    {
        public const string DefaultPath = @"ByTheCakeApplication\Resources\{0}.html";
        public const string PublicPlaceholder = "{{{content}}}";

        public IHttpResponse FileViewResponse(string fileName)
        {
            string result = this.ProcessFileHtml(fileName);

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        public IHttpResponse FileViewResponse(string fileName, Dictionary<string, string> values)
        {
            string result = this.ProcessFileHtml(fileName);

            if (values != null && values.Any())
            {
                foreach (var value in values)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        private string ProcessFileHtml(string filename)
        {
            string layoutHtml = File.ReadAllText(String.Format(DefaultPath, "layout"));

            string fileHtml = File.ReadAllText(String.Format(DefaultPath, filename));

            string result = layoutHtml.Replace(PublicPlaceholder, fileHtml);

            return result;
        }
    }
}