namespace CarDealer.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SupplierModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int NumberOfParts { get; set; }
    }
}