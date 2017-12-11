namespace ProductShop.Data.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [MinLength(3), MaxLength(15)]
        public string Name { get; set; }

        public List<CategoryProduct> Products { get; set; } = new List<CategoryProduct>();
    }
}