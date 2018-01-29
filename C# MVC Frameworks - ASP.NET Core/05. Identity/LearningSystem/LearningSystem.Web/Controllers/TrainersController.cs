namespace LearningSystem.Web.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Trainers;
    using Services;
    using Services.Models;
    using System;
    using System.Threading.Tasks;
    using static WebConstants;

    [Authorize(Roles = TrainerRole)]
    public class TrainersController : Controller
    {
        private readonly ITrainerService trainerService;
        private readonly UserManager<User> userManageer;
        private readonly ICourseService courseService;

        public TrainersController(ITrainerService trainerService, UserManager<User> userManageer, ICourseService courseService)
        {
            this.trainerService = trainerService;
            this.userManageer = userManageer;
            this.courseService = courseService;
        }

        public async Task<IActionResult> Courses()
        {
            var userId = this.userManageer.GetUserId(this.User);

            var courses = await this.trainerService.CourcesByTrainerAsync(userId);

            return this.View(courses);
        }

        public async Task<IActionResult> Students(int courseId)
        {
            var trainerId = this.userManageer.GetUserId(this.User);
            var isTrainerInCourse = await this.trainerService.IsTrainerInCourse(trainerId, courseId);

            if (!isTrainerInCourse)
            {
                return this.NotFound();
            }

            var students = new StudentsInCourseViewModel
            {
                Students = await this.trainerService.StudentsInCourseAsync(courseId),
                Course = await this.courseService.DetailsAsync<CourseListingInfoServiceModel>(courseId)
            };

            return this.View(students);
        }

        [HttpPost]
        public async Task<IActionResult> GradeStudent(int id, string studentId, Grade grade, string studentName)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return this.BadRequest();
            }

            var trainerId = this.userManageer.GetUserId(this.User);
            var isTrainerInCourse = await this.trainerService.IsTrainerInCourse(trainerId, id);

            if (!isTrainerInCourse)
            {
                return this.NotFound();
            }

            bool success = await this.trainerService.AddGradeAsync(id, studentId, grade);

            if (!success)
            {
                return this.BadRequest();
            }

            this.TempData.AddSuccessMessage($"Grade {grade.ToString()} has been added to student {studentName}");
            return this.RedirectToAction(nameof(this.Students), new { courseId = id });
        }

        public async Task<IActionResult> DownloadExam(int courseId, string studentId)
        {

            if (string.IsNullOrEmpty(studentId))
            {
                return this.BadRequest();
            }

            var trainerId = this.userManageer.GetUserId(this.User);
            var isTrainerInCourse = await this.trainerService.IsTrainerInCourse(trainerId, courseId);

            if (!isTrainerInCourse)
            {
                return this.NotFound();
            }

            byte[] examContents = await this.trainerService.GetExamSubmissionAsync(courseId, studentId);

            if (examContents == null)
            {
                this.TempData.AddErrorMessage("There is no submitted exam for this user.");
                return this.RedirectToAction(nameof(this.Students), new { courseId });
            }

            var studentInCourseNames = await this.trainerService.StudentInCourseNamesAsync(courseId, studentId);
            var fileName = $"{studentInCourseNames.CourseTitle}-{studentInCourseNames.Username}-{DateTime.UtcNow:MM-DD-yyyy}.zip";

            return this.File(examContents, "application/zip", fileName);
        }
    }
}