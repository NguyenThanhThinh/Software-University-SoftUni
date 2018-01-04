namespace FDMC.Handlers
{
    using System;
    using Data;
    using Data.Models;
    using Infrastructior;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class AddCatHandler : IHandler
    {
        public int Order => 2;

        public Func<HttpContext, bool> Condition =>
            ctx => ctx.Request.Path.Value == "/cat/add";

        public RequestDelegate RequestHandler =>
            async (ctx) =>
            {
                if (ctx.Request.Method == HttpMethod.Get)
                {
                    ctx.Response.Redirect("/add-cat-form.html");
                }
                else if (ctx.Request.Method == HttpMethod.Post)
                {
                    var db = ctx.RequestServices.GetRequiredService<FdmcDbContext>();

                    var formData = ctx.Request.Form;

                    int age = 0;
                    int.TryParse(formData["Age"], out age);

                    var cat = new Cat
                    {
                        Name = formData["Name"],
                        Age = age,
                        Breed = formData["Breed"],
                        ImageUrl = formData["ImageUrl"]
                    };

                    using (db)
                    {
                        try
                        {
                            if (string.IsNullOrWhiteSpace(cat.Name) ||
                                string.IsNullOrWhiteSpace(cat.Breed) ||
                                string.IsNullOrWhiteSpace(cat.ImageUrl))
                            {
                                throw new InvalidOperationException("Invalid cat data.");
                            }

                            db.Cats.Add(cat);
                            await db.SaveChangesAsync();

                            ctx.Response.Redirect("/");
                        }
                        catch
                        {
                            await ctx.Response.WriteAsync("<h2>Invalid Cat data</h2>");
                            await ctx.Response.WriteAsync(@"<a href=""/cat/add"">Back to the Cat Form</a>");
                        }
                    }
                }
            };
    }
}