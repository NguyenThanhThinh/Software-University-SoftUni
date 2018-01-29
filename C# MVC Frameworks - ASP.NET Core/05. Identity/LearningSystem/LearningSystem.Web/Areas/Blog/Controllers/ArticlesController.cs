namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Blog;
    using Services.Html;
    using System.Threading.Tasks;
    using Web.Controllers;
    using static WebConstants;

    [Area(BlogArea)]
    [Authorize(Roles = BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;
        private readonly UserManager<User> userManager;
        private readonly IHtmlService sanitizer;

        public ArticlesController(IArticleService articleService, UserManager<User> userManager, IHtmlService sanitizer)
        {
            this.articleService = articleService;
            this.userManager = userManager;
            this.sanitizer = sanitizer;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        {
            var articlesForListing = new ArticleListingViewModel
            {
                Articles = await this.articleService.AllAsync(page),
                TotalArticels = await this.articleService.TotalAsync(),
                CurrentPage = page
            };

            return this.View(articlesForListing);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(CreateArticleFormModel model)
        {
            string content = this.sanitizer.HtmlSanitizer(model.Content);

            await this.articleService.CreateAsync(
                content,
                model.Title,
                model.Published,
                this.userManager.GetUserId(this.User));

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var articleDetails = await this.articleService.DetailsAsync(id);

            return this.ViewOrNotFound(articleDetails);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search(string searchText)
        {
            var articlesListing = new ArticleListingSearchViewModel
            {
                Articles = await this.articleService.FindAsync(searchText),
                SearchText = searchText
            };

            return this.View(articlesListing);
        }
    }
}