namespace LearningSystem.Services.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class StudentInCourseExamServiceModel : IMapFrom<StudentCourse>, IHaveCustomMapping
    {
        public string Username { get; set; }

        public string CourseTitle { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<StudentCourse, StudentInCourseExamServiceModel>()
                .ForMember(s => s.CourseTitle, cfg => cfg
                    .MapFrom(sc => sc.Cource.Name))
                .ForMember(s => s.Username, cfg => cfg
                    .MapFrom(sc => sc.Student.Name));
        }
    }
}