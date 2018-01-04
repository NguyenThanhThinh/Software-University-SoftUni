namespace CarDealer.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        public int Id { get; set; }

        public Car Car { get; set; }

        public Customer Customer { get; set; }

        public double Discount { get; set; }

        [Column("Car_Id")]
        public int CarId { get; set; }

        [Column("Customer_Id")]
        public int CustomerId { get; set; }
    }
}