namespace GameStore.App.Infrastructior.Common
{
    public class ValidationConstants
    {
        public const string PasswordsDoNotMatch = "{0} does not match. Please try again.";
        public const string RegisterError = "<p>Check your form for errors.</p><p> E-mails must have at least one '@' and one '.' symbols.</p><p>Passwords must be at least 6 symbols and must contain at least 1 uppercase, 1 lowercase letter and 1 digit.</p><p>Confirm password must match the provided password.</p>";
        public const string EmailExistsError = "E-mail is already taken.";
        public const string LoginError = "Invalid login credentials.";

        public class User
        {
            public const int EmailMinLength = 7;
            public const int EmailMaxLength = 50;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 50;
            public const int FullnameMinLength = 4;
            public const int FullnameMaxLength = 30;
        }

        public class Game
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 70;
            public const int VideoIdLength = 11;
            public const int DescriptionMinLength = 20;
        }
    }
}