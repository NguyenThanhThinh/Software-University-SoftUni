namespace LearningSystem.Web.Models.Trainers
{
    using System.Collections.Generic;
    using Services.Models;

    public class StudentsInCourseViewModel
    {
        public CourseListingInfoServiceModel Course { get; set; }

        public IEnumerable<StudentInCourseServiceModel> Students { get; set; }
    }
}