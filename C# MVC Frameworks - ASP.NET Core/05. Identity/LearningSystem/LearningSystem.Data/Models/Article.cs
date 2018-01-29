namespace LearningSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ArticleTitleMaxLength)]
        [MinLength(ArticleTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ArticleContentMaxLength)]
        [MinLength(ArticleContentMinLength)]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Published { get; set; }

        public User Author { get; set; }

        public string AuthorId { get; set; }
    }
}