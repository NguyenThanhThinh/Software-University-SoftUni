namespace Instagraph.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Picture
    {
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public decimal Size { get; set; }

        [Required]
        public List<User> Users { get; set; } = new List<User>();

        [Required]
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}