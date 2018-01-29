namespace News.Tests.Api.Controllers
{
    using System;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using News.Api.Controllers;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Services.Implementation;
    using Services.Models;
    using Xunit;

    public class NewsControllerTest
    {
        public NewsControllerTest()
        {
            TestStartup.Initilize();
        }

        [Fact]
        public void NewsControllerShouldHaveRouteAttribute()
        {
            //Arrange
            var controller = typeof(NewsController);

            //Act
            var attributes = controller.GetCustomAttributes(true);

            //Assert
            attributes
                .Should()
                .Match(attr => attr.Any(a => a.GetType() == typeof(RouteAttribute)));
        }

        [Fact]
        public async Task ActionGetAllShouldReturnStatusCodeOkAndAllNewsItems()
        {
            //Arrange
            const string Test = "Test";

            var dbOptions = new DbContextOptionsBuilder<NewsDbContext>()
                .UseInMemoryDatabase("NewsDb")
                .Options;

            var db = new NewsDbContext(dbOptions);
            var newsService = new NewsService(db);
            var userController = new NewsController(newsService);

            var news = new News
            {
                Id = 1,
                Title = Test,
                Content = "Test content",
                PublishDate = DateTime.UtcNow
            };

            await db.News.AddAsync(news);
            await db.SaveChangesAsync();

            //Act
            var result = await userController.GetAll();

            //Assert
            result
                .Should()
                .BeOfType<OkObjectResult>()
                .Which.Value.As<NewsFullDetailsServiceModel>();
        }
    }
}