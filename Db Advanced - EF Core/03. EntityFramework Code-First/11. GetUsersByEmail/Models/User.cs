using System;
using System.ComponentModel.DataAnnotations;

namespace _11.GetUsersByEmail.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public string Email { get; set; }

        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime RastTimeLoggedIn { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}