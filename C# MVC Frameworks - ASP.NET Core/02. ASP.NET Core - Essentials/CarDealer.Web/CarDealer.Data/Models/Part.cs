namespace CarDealer.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Part
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<PartCar> Cars { get; set; } = new HashSet<PartCar>();

        public Supplier Supplier { get; set; }

        [Column("Supplier_Id")]
        public int SupplierId { get; set; }
    }
}