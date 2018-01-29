namespace LearningSystem.Data
{
    public static class DataConstants
    {
        public const int UserNameMaxLength = 50;
        public const int UserNameMinLength = 2;

        public const int CourseNameMaxLength = 150;
        public const int CourseNameMinLength = 10;
        public const int CourseDescriptionMaxLength = 500;
        public const int CourseDescriptionMinLength = 10;

        public const int ArticleTitleMaxLength = 150;
        public const int ArticleTitleMinLength = 10;

        public const int ArticleContentMaxLength = 2500;
        public const int ArticleContentMinLength = 10;

        public const int CourseExamSubmissionFileLength = 2 * 1024 * 1024;
    }
}