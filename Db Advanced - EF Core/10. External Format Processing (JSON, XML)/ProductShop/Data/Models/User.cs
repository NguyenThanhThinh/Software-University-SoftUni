namespace ProductShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public List<Product> BoughtProducts { get; set; } = new List<Product>();

        public List<Product> SoldProducts { get; set; } = new List<Product>();
    }
}