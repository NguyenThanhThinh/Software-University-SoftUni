namespace LearningSystem.Web.Models.Home
{
    using System.Collections.Generic;
    using Services.Models;

    public class SearchViewModel
    {
        public IEnumerable<CourseListingInfoServiceModel> Courses { get; set; } = new List<CourseListingInfoServiceModel>();

        public IEnumerable<UserListingServiceModel> Users { get; set; } = new List<UserListingServiceModel>();

        public string SearchText { get; set; }
    }
}