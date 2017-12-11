namespace MyCoolWebServer.GameStoreApplication.Utilities
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PasswordAttribute : ValidationAttribute
    {
        public PasswordAttribute()
        {
            this.ErrorMessage =
                "Password should be at least 6 symbols long, should contain at least 1 uppercase letter, 1 lowercase letter and 1 digit.";
        }

        public override bool IsValid(object value)
        {
            string password = value as string;

            if (password == null)
            {
                return false;
            }

            return password.Any(char.IsLower)
                   && password.Any(char.IsUpper)
                   && password.Any(char.IsDigit);
        }
    }
}