namespace LearningSystem.Services.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System;

    public class CourseDetailsServiceModel : IMapFrom<Cource>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Trainer { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int StudentsCount { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Cource, CourseDetailsServiceModel>()
                .ForMember(c => c.Trainer, cfg => cfg.MapFrom(c => c.Trainer.UserName))
                .ForMember(c => c.StudentsCount, cfg => cfg.MapFrom(c => c.Students.Count));
    }
}