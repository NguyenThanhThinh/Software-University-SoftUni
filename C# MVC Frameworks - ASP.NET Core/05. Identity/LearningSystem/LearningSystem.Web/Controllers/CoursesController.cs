namespace LearningSystem.Web.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Courses;
    using Services;
    using Services.Models;
    using System.Threading.Tasks;
    using static Data.DataConstants;

    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly UserManager<User> userManager;

        public CoursesController(ICourseService courseService, UserManager<User> userManager)
        {
            this.courseService = courseService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Details(int id)
        {
            var courseModel = new CourseDetailsViewModel
            {
                Course = await this.courseService.DetailsAsync<CourseDetailsServiceModel>(id)
            };

            if (courseModel.Course == null)
            {
                return this.NotFound();
            }

            if (this.User.Identity.IsAuthenticated)
            {
                string userId = this.userManager.GetUserId(this.User);

                courseModel.IsUserSignedUp = await this.courseService.UserIsSignedInCourseAsync(id, userId);
            }

            return this.View(courseModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SignUp(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            var isSignedUp = await this.courseService.SignUpAsync(id, userId);

            if (!isSignedUp)
            {
                return this.BadRequest();
            }

            this.TempData.AddSuccessMessage("Successfully Signed Up for this course.");
            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SignOut(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            var isSignedOut = await this.courseService.SignOutAsync(id, userId);

            if (!isSignedOut)
            {
                return this.BadRequest();
            }

            this.TempData.AddSuccessMessage("Successfully Signed out from this course.");
            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SubmitExam(IFormFile exam, int id)
        {
            if (!exam.FileName.EndsWith(".zip") || exam.Length > CourseExamSubmissionFileLength)
            {
                this.TempData.AddErrorMessage("Your submission should be a .zip file with max size 2MG!");
                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            var fileContent = await exam.ToByteArrayAsync();
            string userId = this.userManager.GetUserId(this.User);

            var success = await this.courseService.SaveExamSubmission(id, userId, fileContent);

            if (!success)
            {
                return this.BadRequest();
            }

            this.TempData.AddSuccessMessage("Exam submission saved successfully!");
            return this.RedirectToAction(nameof(this.Details), new { id });
        }
    }
}