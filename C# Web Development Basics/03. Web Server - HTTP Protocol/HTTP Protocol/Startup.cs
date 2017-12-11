namespace HTTP_Protocol
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    public class Startup
    {
        public static void Main()
        {
            /* ***READ BEFORE USE***
             * If you want to test "1.URL Decode", uncomment it.
             * If you want to test "2.Validate URL", uncomment 1.URL Decode and 2.Validate URL
             * If you want to test "3.Request Parser, uncomment it. */

            //// 1.URL Decode
            //string decodedUrl = PerformUrlDecode();

            //// 2.Validate URL
            //bool isUrlValid = ValidateUrl(decodedUrl);

            //if (isUrlValid)
            //{
            //    PrintValidUrlPars(decodedUrl);
            //}
            //else
            //{
            //    Console.WriteLine("Invalid URL");
            //}

            //// 3.Request Parser
            //RequestParser();
        }

        private static void RequestParser()
        {
            Dictionary<string, HashSet<string>> validUrls = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("END"))
                {
                    break;
                }

                string[] splitInput = input.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                string path = "/" + splitInput[0];
                string method = splitInput[1];

                if (!validUrls.ContainsKey(path))
                {
                    validUrls[path] = new HashSet<string>();
                }
                validUrls[path].Add(method);
            }

            string httpRequest = Console.ReadLine();
            string[] httpRequestParts = httpRequest.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string requestMethod = httpRequestParts[0];
            string requestPath = httpRequestParts[1];
            string requestProtocol = httpRequestParts[2];

            if (validUrls.ContainsKey(requestPath) && validUrls[requestPath].Contains(requestMethod.ToLower()))
            {
                Console.WriteLine($"{requestProtocol} 200 OK");
                Console.WriteLine("Content-Length: 2");
                Console.WriteLine("Content-Type: text/plain");
                Console.WriteLine();
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine($"{requestProtocol} 404 NotFound");
                Console.WriteLine("Content-Length: 9");
                Console.WriteLine("Content-Type: text/plain");
                Console.WriteLine();
                Console.WriteLine("NotFound");
            }
        }

        private static void PrintValidUrlPars(string decodedUrl)
        {
            Uri url = new Uri(decodedUrl);

            Console.WriteLine($"Protocol: {url.Scheme}");
            Console.WriteLine($"Host: {url.Host}");
            Console.WriteLine($"Port: {url.Port}");
            Console.WriteLine($"Path: {url.AbsolutePath}");

            string query = url.Query;
            string fragment = url.Fragment;

            if (!string.IsNullOrEmpty(query))
            {
                Console.WriteLine($"Query: {query}");
            }

            if (!string.IsNullOrEmpty(fragment))
            {
                Console.WriteLine($"Fragment: {fragment.Substring(1)}");
            }
        }

        private static bool ValidateUrl(string decodedUrl)
        {
            const string http = "http";
            const string https = "https";

            Uri url = new Uri(decodedUrl);

            bool isUrlValid = true;

            string protocol = url.Scheme;
            if (string.IsNullOrEmpty(protocol))
            {
                isUrlValid = false;
            }

            if (string.IsNullOrEmpty(url.Host))
            {
                isUrlValid = false;
            }

            string port = url.Port.ToString();
            if (string.IsNullOrEmpty(port))
            {
                isUrlValid = false;
            }
            else
            {
                if (protocol.Equals(http) && port == "443")
                {
                    isUrlValid = false;
                }
                if (protocol.Equals(https) && port == "80")
                {
                    isUrlValid = false;
                }
            }

            if (string.IsNullOrEmpty(url.AbsolutePath))
            {
                isUrlValid = false;
            }

            return isUrlValid;
        }

        private static string PerformUrlDecode()
        {
            string encodedUrl = Console.ReadLine();

            string decodedUrl = WebUtility.UrlDecode(encodedUrl);

            return decodedUrl;
        }
    }
}