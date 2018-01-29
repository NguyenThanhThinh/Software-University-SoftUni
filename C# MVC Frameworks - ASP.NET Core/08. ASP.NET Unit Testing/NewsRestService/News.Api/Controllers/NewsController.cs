namespace News.Api.Controllers
{
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.News;
    using Services;
    using System.Threading.Tasks;
    using Infrastructure.Extensions;
    using static ApiConstants;

    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => this.Ok(await this.newsService.All());

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody]GeneralNewsRequestModel newsModel)
            => this.Ok(await this.newsService.Create(
                newsModel.Title,
                newsModel.Content,
                newsModel.PublishDate));

        [HttpPut(WithId)]
        [ValidateModelState]
        public async Task<IActionResult> UpdateById(int id, [FromBody]GeneralNewsRequestModel newsModel)
            => this.OkOrNotFound(await this.newsService.UpdateById(id,
                    newsModel.Title, newsModel.Content, newsModel.PublishDate));

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var idResult = await this.newsService.Delete(id);

            if (idResult == 0)
            {
                return this.NotFound($"No news with Id {id} was founded.");
            }

            return this.Ok(id);
        }
    }
}