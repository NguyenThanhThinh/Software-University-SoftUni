namespace BookShop.Api.Models.Categories
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class EditCategoryNameRequestModel
    {
        [Required]
        [MinLength(CategoryNameMinLeght)]
        [MaxLength(CategoryNameMaxLeght)]
        public string Name { get; set; }
    }
}