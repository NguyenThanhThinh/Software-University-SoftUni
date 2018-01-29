namespace LearningSystem.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TrainerService : ITrainerService
    {
        private readonly LearningSystemDbContext db;

        public TrainerService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseListingInfoServiceModel>> CourcesByTrainerAsync(string trainerId)
        {
            return await this.db.Cources
                .Where(c => c.TrainerId == trainerId)
                .ProjectTo<CourseListingInfoServiceModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<StudentInCourseServiceModel>> StudentsInCourseAsync(int courseId)
        {
            return await this.db.Users
                .Where(u => u.Courses.Any(sc => sc.CourseId == courseId))
                .ProjectTo<StudentInCourseServiceModel>(new { courseId })
                .ToListAsync();
        }

        public Task<bool> IsTrainerInCourse(string trainerId, int courseId)
        {
            return this.db.Cources
                .AnyAsync(c => c.TrainerId == trainerId && c.Id == courseId);
        }

        public async Task<bool> AddGradeAsync(int courseId, string studentId, Grade grade)
        {
            var course = await this.db.StudentCourses
                .FirstOrDefaultAsync(sc => sc.CourseId == courseId && sc.StudentId == studentId);

            if (course == null)
            {
                return false;
            }

            course.Grade = grade;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<byte[]> GetExamSubmissionAsync(int courseId, string studentId)
        {
            var course = await this.db.StudentCourses
                .FirstOrDefaultAsync(sc => sc.CourseId == courseId && sc.StudentId == studentId);

            return course?.ExamSubmission;
        }

        public async Task<StudentInCourseExamServiceModel> StudentInCourseNamesAsync(int courseId, string studentId)
        {
            var studentInCourse = await this.db.StudentCourses
                .Where(sc => sc.StudentId == studentId && sc.CourseId == courseId)
                .ProjectTo<StudentInCourseExamServiceModel>()
                .FirstOrDefaultAsync();

            return studentInCourse;
        }
    }
}