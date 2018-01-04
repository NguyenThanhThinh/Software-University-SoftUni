namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;

    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SaleModel> Index()
        {
            var sales = this.db.Sales
                .Select(s => new SaleModel
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance,
                    Customer = s.Customer.Name,
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                    Discount = s.Discount + (s.Customer.IsYoungDriver ? 5 : 0)
                })
                .ToList();

            return sales;
        }

        public IEnumerable<SaleModel> Index(int id)
        {
            var sale = this.db.Sales
                .Where(s => s.Id == id)
                .Select(s => new SaleModel
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance,
                    Customer = s.Customer.Name,
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                    Discount = s.Discount + (s.Customer.IsYoungDriver ? 5 : 0)
                })
                .ToList();

            return sale;
        }

        public IEnumerable<SaleModel> Discounted()
        {
            var sales = this.db.Sales
                .Select(s => new SaleModel
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance,
                    Customer = s.Customer.Name,
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                    Discount = s.Discount + (s.Customer.IsYoungDriver ? 5 : 0)
                })
                .Where(s => s.Discount > 0)
                .ToList();

            return sales;
        }

        public IEnumerable<SaleModel> Discounted(double percentage)
        {
            var sales = this.db.Sales
                .Select(s => new SaleModel
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance,
                    Customer = s.Customer.Name,
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                    Discount = s.Discount + (s.Customer.IsYoungDriver ? 5 : 0)
                })
                .Where(s => s.Discount == percentage)
                .ToList();

            return sales;
        }
    }
}