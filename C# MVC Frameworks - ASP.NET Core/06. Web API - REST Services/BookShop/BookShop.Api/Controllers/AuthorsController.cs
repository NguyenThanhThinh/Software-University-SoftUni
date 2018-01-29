namespace BookShop.Api.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Authors;
    using Services;
    using System.Threading.Tasks;

    using static ApiConstants;

    public class AuthorsController : BaseController
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.authorService.GetByIdAsync(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] PostAuthorRequestModel authorModel)
        {
            await this.authorService.CreateAsync(authorModel.FirstName, authorModel.LastName);
            return this.Ok(authorModel);
        }

        [HttpGet(WithId + "/books")]
        public async Task<IActionResult> Books(int id)
            => this.OkOrNotFound(await this.authorService.GetBooksAsync(id));
    }
}