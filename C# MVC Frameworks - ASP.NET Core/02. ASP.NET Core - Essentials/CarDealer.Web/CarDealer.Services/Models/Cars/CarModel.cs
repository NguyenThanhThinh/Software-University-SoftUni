namespace CarDealer.Services.Models.Cars
{
    using System.ComponentModel.DataAnnotations;

    public class CarModel
    {
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Range(0, long.MaxValue)]
        public long TravelledDistance { get; set; }
    }
}