namespace Instagraph.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml;
    using System.Xml.Serialization;

    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Caption { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public int PictureId { get; set; }

        [Required]
        public Picture Picture { get; set; }

        [Required]
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}