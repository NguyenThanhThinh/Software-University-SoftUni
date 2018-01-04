namespace CarDealer.Services.Models.Parts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PartModel
    {
        [Required]
        public string PartName { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public double? Price { get; set; }
    }
}