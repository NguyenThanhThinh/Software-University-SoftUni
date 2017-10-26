namespace SalesDatabase.Models
{
    using System.ComponentModel;
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.SalesOfProduct = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        [DefaultValue("No description")]
        public string Description { get; set; }

        public ICollection<Sale> SalesOfProduct { get; set; }
    }
}