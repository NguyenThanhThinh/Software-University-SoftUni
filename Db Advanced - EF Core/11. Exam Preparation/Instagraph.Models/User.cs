namespace Instagraph.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public int ProfilePictureId { get; set; }

        [Required]
        public Picture ProfilePicture { get; set; }

        [Required]
        public List<UserFollower> Followers { get; set; } = new List<UserFollower>();

        [Required]
        public List<UserFollower> UsersFollowing { get; set; } = new List<UserFollower>();

        [Required]
        public List<Post> Posts { get; set; } = new List<Post>();

        [Required]
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}