namespace GameStore.App.Infrastructior.Utilities
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using SimpleMvc.Framework.Attributes.Validation;

    public class PasswordAttribute : PropertyValidationAttribute
    {
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