namespace CarDealer.Services.Models
{
    public class SaleModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public decimal TravelledDistance { get; set; }

        public string Customer { get; set; }

        public double? Price { get; set; }

        public double Discount { get; set; }
    }
}