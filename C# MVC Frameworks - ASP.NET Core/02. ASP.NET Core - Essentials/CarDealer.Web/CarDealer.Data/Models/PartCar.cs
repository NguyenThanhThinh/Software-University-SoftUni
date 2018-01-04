namespace CarDealer.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class PartCar
    {
        public Part Part { get; set; }

        [Column("Part_Id")]
        public int PartId { get; set; }

        public Car Car { get; set; }

        [Column("Car_Id")]
        public int CarId { get; set; }
    }
}