using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _08.Create_User
{
    public class User
    {
        private string username;
        private string password;
        private string email;
        private byte[] profilePicture = new byte[1000000];
        private int age;

        [Key]
        public int Id { get; set; }

        [MinLength(4), MaxLength(30),]
        public string Username
        {
            get { return this.username; }
            set
            {
                if (value.Length < 4 || value.Length > 30)
                {
                    throw new ArgumentException("Username should be 4 to 30 characters long");
                }
                this.username = value;
            }
        }

        [Required]
        [MinLength(6), MaxLength(50)]
        public string Password
        {
            get { return this.password; }
            set
            {
                if (this.IsPasswordInvalid(value))
                {
                    throw new ArgumentException("Password should contain at least: 1 lowercase letter, 1 uppercase letter, 1 digit, " +
                                                "1 special symbol (!, @, #, $, %, ^, &, *, (, ), _, +, <, >, ?)");
                }
                this.password = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (this.IsEmailInvalid(value))
                {
                    throw new ArgumentException("Invalid email!");
                }

                this.email = value;
            }
        }

        [MaxLength(1000000)]
        public byte[] ProfilePicture
        {
            get { return this.profilePicture; }
            set
            {
                if (value.Length > 1000000)
                {
                    throw new ArgumentException("Picture size is too big. Max size 1Mb!");
                }

                this.profilePicture = value;
            }
        }

        public DateTime RegisteredOn { get; set; }

        public DateTime RastTimeLoggedIn { get; set; }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1 || value > 120)
                {
                    throw new ArgumentException("Age should be in range [1-120]!");
                }
                this.age = value;
            }
        }

        public bool IsDeleted { get; set; }

        private bool IsPasswordInvalid(string value)
        {
            string pattern = @"(?=.*[0-9])(?=.*[!@#$%^&*()_+<>?])(?=.*[a-z])(?=.*[A-Z])";

            if (Regex.IsMatch(value, pattern))
            {
                return false;
            }

            return true;
        }

        private bool IsEmailInvalid(string value)
        {
            string pattern = @"^[a-zA-Z0-9]+[a-zA-Z0-9\.\-_]*[a-zA-Z0-9]*@[a-zA-Z\.-]+\.[\w]{2,3}$";

            if (Regex.IsMatch(value, pattern))
            {
                return false;
            }

            return true;
        }
    }
}