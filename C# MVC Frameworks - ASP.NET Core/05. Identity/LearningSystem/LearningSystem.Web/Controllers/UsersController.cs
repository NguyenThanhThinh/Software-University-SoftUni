namespace LearningSystem.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System.Threading.Tasks;

    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public UsersController(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Profile(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return this.NotFound();
            }

            var userProfile = await this.userService.ProfileAsync(user.Id);

            return this.View(userProfile);
        }

        public async Task<IActionResult> DownloadCertificate(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            var certificateContents = await this.userService.GetPdfCertificateAsync(id, userId);

            if (certificateContents == null)
            {
                return this.BadRequest();
            }

            return this.File(certificateContents, "application/pdf", "Certificate.pdf");
        }
    }
}