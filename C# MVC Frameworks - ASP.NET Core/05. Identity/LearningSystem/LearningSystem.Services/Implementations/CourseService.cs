namespace LearningSystem.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;

        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseListingInfoServiceModel>> ActiveAsync()
        {
            var courses = await this.db.Cources
                .Where(c => c.EndDate >= DateTime.UtcNow)
                .Select(c => new CourseListingInfoServiceModel
                {
                    Name = c.Name,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Id = c.Id
                })
                .OrderBy(c => c.StartDate)
                .ToListAsync();

            return courses;
        }

        public async Task<TModel> DetailsAsync<TModel>(int id)
            where TModel : class
        {
            var course = await this.db.Cources
                .Where(c => c.Id == id)
                .ProjectTo<TModel>()
                .FirstOrDefaultAsync();

            return course;
        }

        public async Task<bool> UserIsSignedInCourseAsync(int courseId, string studendId)
        {
            return await this.db.StudentCourses.AnyAsync(sc => sc.CourseId == courseId && sc.StudentId == studendId);
        }

        public async Task<bool> SignUpAsync(int courseId, string userId)
        {
            var courseIsValid = this.db.Cources.Any(c => c.Id == courseId);

            if (!courseIsValid)
            {
                return false;
            }

            this.db.StudentCourses
                .Add(new StudentCourse
                {
                    CourseId = courseId,
                    StudentId = userId
                });

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SignOutAsync(int courseId, string userId)
        {
            var courseIsValid = this.db.Cources.Any(c => c.Id == courseId);

            if (!courseIsValid)
            {
                return false;
            }

            this.db.StudentCourses
                .Remove(new StudentCourse
                {
                    CourseId = courseId,
                    StudentId = userId
                });

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CourseListingInfoServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            var courses = await this.db.Cources
                .OrderByDescending(c => c.Id)
                .Where(c => c.Name.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<CourseListingInfoServiceModel>()
                .ToListAsync();

            return courses;
        }

        public async Task<bool> SaveExamSubmission(int courseId, string studentId, byte[] fileContent)
        {
            var studentCourse = await this.db.StudentCourses
                .FirstOrDefaultAsync(sc => sc.CourseId == courseId &&
                                sc.StudentId == studentId);

            if (studentCourse == null)
            {
                return false;
            }

            studentCourse.ExamSubmission = fileContent;

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}