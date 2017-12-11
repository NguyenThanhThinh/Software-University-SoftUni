namespace GameStore.App.Infrastructior.Utilities
{
    using SimpleMvc.Framework.Attributes.Validation;
    using System.Linq;

    class EmailAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;

            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            return email.Any(e => e == '@')
                   && email.Any(e => e == '.');
        }
    }
}