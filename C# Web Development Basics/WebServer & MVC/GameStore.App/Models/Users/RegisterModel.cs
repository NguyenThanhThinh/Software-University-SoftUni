namespace GameStore.App.Models.Users
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructior.Common;
    using Infrastructior.Utilities;

    public class RegisterModel
    {
        [Display(Name = "E-mail")]
        [Required]
        [Email]
        public string Email { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        public string Fullname { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required]
        [Password]
        [Compare(nameof(Password), ErrorMessage = ValidationConstants.PasswordsDoNotMatch)]
        public string ConfirmPassword { get; set; }
    }
}