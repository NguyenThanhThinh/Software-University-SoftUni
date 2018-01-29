namespace LearningSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Home;
    using Services;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IUserService userService;

        public HomeController(ICourseService courseService, IUserService userService)
        {
            this.courseService = courseService;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var activeCourses = await this.courseService.ActiveAsync();

            return this.View(new HomeIndexViewModel
            {
                Courses = activeCourses
            });
        }

        public async Task<IActionResult> Search(SearchFormModel model)
        {
            string searchText = model.SearchText;

            var viewModel = new SearchViewModel
            {
                SearchText = searchText
            };

            if (model.SearchInCourses)
            {
                viewModel.Courses = await this.courseService.FindAsync(searchText);
            }

            if (model.SearchInUsers)
            {
                viewModel.Users = await this.userService.FindAsync(searchText);
            }

            return this.View(viewModel);
        }
    }
}
