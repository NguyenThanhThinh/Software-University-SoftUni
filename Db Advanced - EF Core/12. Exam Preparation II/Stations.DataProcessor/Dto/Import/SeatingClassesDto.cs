namespace Stations.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;

    public class SeatingClassesDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2), MinLength(2)]
        public string Abbreviation { get; set; }
    }
}