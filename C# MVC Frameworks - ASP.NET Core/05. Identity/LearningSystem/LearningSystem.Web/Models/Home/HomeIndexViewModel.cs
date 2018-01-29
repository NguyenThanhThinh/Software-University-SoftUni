namespace LearningSystem.Web.Models.Home
{
    using Services.Models;
    using System.Collections.Generic;

    public class HomeIndexViewModel : SearchFormModel
    {
        public IEnumerable<CourseListingInfoServiceModel> Courses { get; set; }
    }
}