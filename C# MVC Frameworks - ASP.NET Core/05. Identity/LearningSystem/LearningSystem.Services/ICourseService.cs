namespace LearningSystem.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingInfoServiceModel>> ActiveAsync();

        Task<TModel> DetailsAsync<TModel>(int id) where TModel : class;

        Task<bool> UserIsSignedInCourseAsync(int courseId, string studendId);

        Task<bool> SignUpAsync(int courseId, string userId);

        Task<bool> SignOutAsync(int courseId, string userId);

        Task<IEnumerable<CourseListingInfoServiceModel>> FindAsync(string searchText);

        Task<bool> SaveExamSubmission(int courseId, string studentId, byte[] fileContent);
    }
}