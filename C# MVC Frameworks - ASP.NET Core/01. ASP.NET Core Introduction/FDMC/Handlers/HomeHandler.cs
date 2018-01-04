namespace FDMC.Handlers
{
    using System;
    using System.Linq;
    using Data;
    using Infrastructior;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class HomeHandler : IHandler
    {
        public int Order => 1;

        public Func<HttpContext, bool> Condition =>
            ctx => ctx.Request.Path.Value == "/" && ctx.Request.Method == HttpMethod.Get;

        public RequestDelegate RequestHandler => async context =>
        {
            await context.Response.WriteAsync(String.Format(HtmlTags.HeadingOne, "Fluffy Duffy Munchkin Cats"));

            var db = context.RequestServices.GetRequiredService<FdmcDbContext>();

            using (db)
            {
                var catsData = db.Cats
                    .Select(c => new
                    {
                        c.Name,
                        c.Id
                    })
                    .ToList();

                await context.Response.WriteAsync("<ul>");

                foreach (var cat in catsData)
                {
                    await context.Response.WriteAsync($@"<li><a href=""/cat/{cat.Id}"">{cat.Name}</a></li>");
                }

                await context.Response.WriteAsync("</ul>");

                await context.Response.WriteAsync(HtmlTags.AddCatButton);
            }
        };
    }
}