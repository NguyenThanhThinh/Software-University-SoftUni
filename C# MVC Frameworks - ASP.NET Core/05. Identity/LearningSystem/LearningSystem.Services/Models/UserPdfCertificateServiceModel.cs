namespace LearningSystem.Services.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System;

    public class UserPdfCertificateServiceModel : IMapFrom<StudentCourse>, IHaveCustomMapping
    {
        public string CourseName { get; set; }

        public DateTime CourseStartDate { get; set; }

        public DateTime CourseEndDate { get; set; }

        public string StudentName { get; set; }

        public Grade StudentGrade { get; set; }

        public string Trainer { get; set; }

        public string UtcNow { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<StudentCourse, UserPdfCertificateServiceModel>()
                .ForMember(u => u.CourseName, cfg => cfg
                    .MapFrom(sc => sc.Cource.Name))
                .ForMember(u => u.CourseStartDate, cfg => cfg
                    .MapFrom(sc => sc.Cource.StartDate))
                .ForMember(u => u.CourseEndDate, cfg => cfg
                    .MapFrom(sc => sc.Cource.EndDate))
                .ForMember(u => u.StudentName, cfg => cfg
                    .MapFrom(sc => sc.Student.Name))
                .ForMember(u => u.StudentGrade, cfg => cfg
                    .MapFrom(sc => sc.Grade))
                .ForMember(u => u.Trainer, cfg => cfg
                    .MapFrom(sc => sc.Cource.Trainer.Name));
        }
    }
}