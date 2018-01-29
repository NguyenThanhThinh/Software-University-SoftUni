namespace LearningSystem.Web.Models.Manage
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class IndexViewModel
    {
        public string Username { get; set; }

        [Required]
        [MaxLength(UserNameMaxLength, ErrorMessage = "The {0} must be with max {1} characters long.")]
        [MinLength(UserNameMinLength, ErrorMessage = "The {0} must be with min {1} characters long.")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
