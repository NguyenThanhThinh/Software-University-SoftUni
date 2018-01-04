namespace CarDealer.Services.Models.Customers
{
    public class CustomerByIdModel
    {
        public string Name { get; set; }

        public int BoughtCars { get; set; }

        public double? TotalMoneySpend { get; set; }
    }
}