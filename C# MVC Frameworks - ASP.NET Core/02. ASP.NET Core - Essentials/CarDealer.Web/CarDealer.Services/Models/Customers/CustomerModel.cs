namespace CarDealer.Services.Models.Customers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be with minimum length of 2 and maximum of 100"), MaxLength(100)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}