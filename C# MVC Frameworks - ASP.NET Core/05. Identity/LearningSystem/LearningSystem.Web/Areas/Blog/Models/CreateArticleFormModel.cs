namespace LearningSystem.Web.Areas.Blog.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class CreateArticleFormModel
    {
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

        public string AuthorId { get; set; }
    }
}