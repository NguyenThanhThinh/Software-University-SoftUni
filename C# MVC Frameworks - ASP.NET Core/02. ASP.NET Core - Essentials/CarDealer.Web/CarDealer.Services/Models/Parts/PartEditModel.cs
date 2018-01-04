namespace CarDealer.Services.Models.Parts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PartEditModel
    {
        [Range(0.1, Double.MaxValue)]
        public double? Price { get; set; }

        [Range(0, Double.MaxValue)]
        public int Quantity { get; set; }
    }
}