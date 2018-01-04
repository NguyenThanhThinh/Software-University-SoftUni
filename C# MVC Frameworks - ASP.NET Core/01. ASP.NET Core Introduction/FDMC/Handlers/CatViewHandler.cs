namespace FDMC.Handlers
{
    using System;
    using Data;
    using Infrastructior;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class CatViewHandler : IHandler
    {
        public int Order => 3;

        public Func<HttpContext, bool> Condition =>
            ctx => ctx.Request.Path.Value.StartsWith("/cat")
                   && ctx.Request.Method == HttpMethod.Get;

        public RequestDelegate RequestHandler =>
            async ctx =>
            {
                var urlParts = ctx.Request.Path.Value.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

                if (urlParts.Length < 2)
                {
                    ctx.Response.Redirect("/");
                    return;
                }

                int catId = 0;
                int.TryParse(urlParts[1], out catId);

                var db = ctx.RequestServices.GetRequiredService<FdmcDbContext>();

                using (db)
                {
                    var cat = await db.Cats.FindAsync(catId);

                    if (cat == null)
                    {
                        ctx.Response.Redirect("/");
                        return;
                    }

                    await ctx.Response.WriteAsync($@"{string.Format(HtmlTags.HeadingOne, cat.Name)}");
                    await ctx.Response.WriteAsync($@"<img src=""{cat.ImageUrl}"" alt=""{cat.Name}"" width=""{300}""/>");
                    await ctx.Response.WriteAsync($"<p><strong>Age:<strong> {cat.Age}</p>");
                    await ctx.Response.WriteAsync($"<p><strong>Breed:<strong> {cat.Breed}</p>");
                }
            };
    }
}