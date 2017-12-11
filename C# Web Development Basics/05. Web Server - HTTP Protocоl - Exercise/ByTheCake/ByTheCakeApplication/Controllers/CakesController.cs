namespace ByTheCake.ByTheCakeApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Infrastructure;
    using Models;
    using Server.HTTP.Contracts;

    public class CakesController : Controller
    {
        private const string DatabasePath = @"ByTheCakeApplication\Data\database.csv";

        private static readonly List<Cake> Cakes = new List<Cake>();

        public IHttpResponse Add() => this.FileViewResponse(@"Cakes\add", new Dictionary<string, string>
        {
            ["showResult"] = "none"
        });

        public IHttpResponse Add(string name, string price)
        {
            var cake = new Cake
            {
                Name = name,
                Price = decimal.Parse(price)
            };

            Cakes.Add(cake);

            using (var streamWriter = new StreamWriter(DatabasePath, true))
            {
                streamWriter.WriteLine($"{name},{price}");
            }

            return this.FileViewResponse(@"Cakes\add", new Dictionary<string, string>
            {
                ["name"] = name,
                ["price"] = price,
                ["showResult"] = "block"
            });
        }

        public IHttpResponse Search(IDictionary<string, string> urlParamaters)
        {
            string searchTermKey = "searchTerm";

            string results = String.Empty;

            if (urlParamaters.ContainsKey(searchTermKey))
            {
                string searchTerm = urlParamaters[searchTermKey];

                var savedCakesDivs = File
                    .ReadAllLines(DatabasePath)
                    .Where(l => l.Contains(','))
                    .Select(l => l.Split(','))
                    .Select(line => new Cake
                    {
                        Name = line[0],
                        Price = decimal.Parse(line[1])
                    })
                        .Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()))
                        .Select(c => $"<div>{c.Name} - ${c.Price}</div>");

                results = string.Join(Environment.NewLine, savedCakesDivs);
            }

            return this.FileViewResponse(@"Cakes\search", new Dictionary<string, string>
            {
                ["results"] = results
            });
        }
    }
}