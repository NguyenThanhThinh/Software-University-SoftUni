namespace LearningSystem.Services.Admin
{
    using System;
    using System.Threading.Tasks;

    public interface IAdminCourseService
    {
        Task CreateAsync(string name, string description, string trainerId, DateTime startDate, DateTime endDate);
    }
}