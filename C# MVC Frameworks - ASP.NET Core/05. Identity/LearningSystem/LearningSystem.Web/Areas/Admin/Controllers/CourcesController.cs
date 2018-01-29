namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Courses;
    using Services.Admin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static WebConstants;

    public class CourcesController : BaseAdminController
    {
        private readonly UserManager<User> userManager;
        private readonly IAdminCourseService courceService;

        public CourcesController(UserManager<User> userManager, IAdminCourseService courceService)
        {
            this.userManager = userManager;
            this.courceService = courceService;
        }

        public async Task<IActionResult> CreateAsync()
        {
            CreateCourseFormModel model = new CreateCourseFormModel
            {
                Trainers = await this.GetTrainers(),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(7)
            };

            return this.View(model);
        }

        [HttpPost]

        public async Task<IActionResult> CreateAsync(CreateCourseFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Trainers = await this.GetTrainers();
                return this.View(model);
            }

            string courseName = model.Name;

            await this.courceService.CreateAsync(
                courseName,
                model.Description,
                model.TrainerId,
                model.StartDate,
                model.EndDate.AddDays(1)
            );

            this.TempData.AddSuccessMessage($"Course '{courseName}' was created successfully.");
            return this.RedirectToAction(nameof(this.CreateAsync));
        }

        private async Task<IEnumerable<SelectListItem>> GetTrainers()
        {
            var trainers = await this.userManager.GetUsersInRoleAsync(TrainerRole);

            var trainerListItems = trainers
                .Select(t => new SelectListItem
                {
                    Text = t.UserName,
                    Value = t.Id
                })
                .ToList();

            return trainerListItems;
        }
    }
}