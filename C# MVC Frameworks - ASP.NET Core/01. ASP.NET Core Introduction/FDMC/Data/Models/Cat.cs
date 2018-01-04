namespace FDMC.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Cat
    {
        public const int MinStringLength = 1;
        public const int MaxStringLength = 50;

        public int Id { get; set; }

        [Required]
        [MinLength(MinStringLength)]
        [MaxLength(MaxStringLength)]
        public string Name { get; set; }

        [Range(0, 30)]
        public int Age { get; set; }

        [Required]
        [MinLength(MinStringLength)]
        [MaxLength(MaxStringLength)]
        public string Breed { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        public string ImageUrl { get; set; }
    }
}