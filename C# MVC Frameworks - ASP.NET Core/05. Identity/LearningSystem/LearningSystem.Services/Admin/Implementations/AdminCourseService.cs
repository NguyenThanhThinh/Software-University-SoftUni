namespace LearningSystem.Services.Admin.Implementations
{
    using Data;
    using Data.Models;
    using System;
    using System.Threading.Tasks;

    public class AdminCourseService : IAdminCourseService
    {
        private readonly LearningSystemDbContext db;

        public AdminCourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string name, string description, string trainerId, DateTime startDate, DateTime endDate)
        {
            var course = new Cource
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                TrainerId = trainerId
            };

            this.db.Cources.Add(course);
            await this.db.SaveChangesAsync();
        }
    }
}