using System.ComponentModel.DataAnnotations;

namespace Stations.DataProcessor.Dto.Import.Train
{
    public class SeatDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2), MinLength(2)]
        public string Abbreviation { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }
    }
}