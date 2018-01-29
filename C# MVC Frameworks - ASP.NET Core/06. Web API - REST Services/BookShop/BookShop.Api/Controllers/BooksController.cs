namespace BookShop.Api.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Books;
    using Services;
    using System.Threading.Tasks;

    using static ApiConstants;

    public class BooksController : BaseController
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;

        public BooksController(IBookService bookService, IAuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Books(int id)
            => this.OkOrNotFound(await this.bookService.GetByIdAsync(id));

        [HttpGet]
        public async Task<IActionResult> TopBooks([FromQuery]string search = "")
            => this.OkOrNotFound(await this.bookService.GetTopBooksByTitleAscendingAsync(search));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody]CreateBookRequestModel bookModel)
        {
            if (!await this.authorService.Exist(bookModel.AuthorId))
            {
                return this.BadRequest("Author does not exists.");
            }

            var id = await this.bookService.Create(
                bookModel.Title,
                bookModel.Description,
                bookModel.Price,
                bookModel.Copies,
                bookModel.Edition,
                bookModel.AgeRestriction,
                bookModel.ReleaseDate,
                bookModel.CategoryNames,
                bookModel.AuthorId);

            return this.Ok(id);
        }

        [HttpPut(WithId)]
        [ValidateModelState]
        public async Task<IActionResult> EditById(int id, [FromBody]EditBookByIdRequestModel bookModel)
        {
            var success = await this.bookService.EditByIdAsync(
                id,
                bookModel.Title,
                bookModel.Description,
                bookModel.Price,
                bookModel.Copies,
                bookModel.Edition,
                bookModel.AgeRestriction,
                bookModel.ReleaseDate,
                bookModel.AuthorId);

            if (!success)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var sucess = await this.bookService.Delete(id);

            if (!sucess)
            {
                return this.BadRequest($"No book with id {id} exist.");
            }

            return this.Ok(id);
        }
    }
}