namespace _02.Photo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Photographer
    {
        [Key]
        public int PhotographerId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime RegisteredDate { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public IList<PhotographerAlbum> PhotographerAlbums { get; set; } = new List<PhotographerAlbum>();
    }
}