namespace BookShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(PriceMinLength, PriceMaxLength)]
        public double Price { get; set; }

        [Required]
        [Range(CopiesMinLegth, CopiesMaxLength)]
        public int Copies { get; set; }

        [Required]
        [MinLength(EditionMinLength)]
        [MaxLength(EditionMaxLength)]
        public string Edition { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int? AgeRestriction { get; set; }

        public Author Author { get; set; }

        public int AuthorId { get; set; }

        public List<CategoryBook> Categories { get; set; } = new List<CategoryBook>();
    }
}