namespace LearningSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class StudentCourse
    {
        public string StudentId { get; set; }

        public User Student { get; set; }

        public int CourseId { get; set; }

        public Cource Cource { get; set; }

        public Grade? Grade { get; set; }

        [MaxLength(CourseExamSubmissionFileLength)]
        public byte[] ExamSubmission { get; set; }
    }
}