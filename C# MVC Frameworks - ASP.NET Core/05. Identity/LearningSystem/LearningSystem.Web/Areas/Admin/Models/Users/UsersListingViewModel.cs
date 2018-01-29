namespace LearningSystem.Web.Areas.Admin.Models.Users
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Admin.Models;
    using System.Collections.Generic;

    public class UsersListingViewModel
    {
        public IEnumerable<UserServiceListingModel> UsersListing { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}