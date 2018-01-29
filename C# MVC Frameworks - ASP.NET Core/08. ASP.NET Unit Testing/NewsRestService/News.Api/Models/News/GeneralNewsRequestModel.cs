namespace News.Api.Models.News
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class GeneralNewsRequestModel
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ContextMinLength)]
        [MaxLength(ContextMaxLength)]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
    }
}