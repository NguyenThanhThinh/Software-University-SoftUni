namespace GameStore.App.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Infrastructior.Common;

    public class User
    {
        public int UserId { get; set; }

        [Required]
        [MinLength(ValidationConstants.User.EmailMinLength),
         MaxLength(ValidationConstants.User.EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MinLength(ValidationConstants.User.PasswordMinLength),
         MaxLength(ValidationConstants.User.PasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [MinLength(ValidationConstants.User.FullnameMinLength),
         MaxLength(ValidationConstants.User.FullnameMaxLength)]
        public string Fullname { get; set; }

        public IList<UserGame> Games { get; set; } = new List<UserGame>();

        public bool IsAdmin { get; set; }
    }
}