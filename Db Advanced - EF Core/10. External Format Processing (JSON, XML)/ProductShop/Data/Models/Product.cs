namespace ProductShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? BuyerId { get; set; }

        public User Buyer { get; set; }

        [Required]
        public int SellerId { get; set; }

        [Required]
        public User Seller { get; set; }

        public List<CategoryProduct> Categories { get; set; } = new List<CategoryProduct>();
    }
}