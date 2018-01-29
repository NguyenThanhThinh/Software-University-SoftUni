namespace LearningSystem.Web.Models.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(UserNameMaxLength, ErrorMessage = "The {0} must be with max {1} characters long.")]
        [MinLength(UserNameMinLength, ErrorMessage = "The {0} must be with min {1} characters long.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(UserNameMaxLength, ErrorMessage = "The {0} must be with max {1} characters long.")]
        [MinLength(UserNameMinLength, ErrorMessage = "The {0} must be with min {1} characters long.")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}