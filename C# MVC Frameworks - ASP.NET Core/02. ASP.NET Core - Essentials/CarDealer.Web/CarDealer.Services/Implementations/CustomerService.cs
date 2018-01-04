namespace CarDealer.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;
    using Models.Customers;
    using Data.Models;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CustomerModel> OrderCustomers(OrderType orderBy)
        {
            var customers = this.db.Customers.AsQueryable();

            switch (orderBy)
            {
                case OrderType.Ascending:
                    customers = customers
                        .OrderBy(c => c.BirthDate)
                        .ThenBy(c => c.IsYoungDriver);
                    break;

                case OrderType.Descending:
                    customers = customers
                        .OrderByDescending(c => c.BirthDate)
                        .ThenBy(c => c.IsYoungDriver);
                    break;

                default:
                    throw new NotImplementedException($"Invalid order by {orderBy}");
            }

            return customers
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Birthday = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();
        }

        public CustomerByIdModel CustomerById(int id)
        {
            var customerById = this.db.Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerByIdModel
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    TotalMoneySpend = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Part.Price))
                })
                .FirstOrDefault();

            return customerById;
        }

        public void Add(string name, DateTime birthDay)
        {
            bool isYoungDriver = this.IsYoungDriver(birthDay);

            Customer customer = new Customer
            {
                Name = name,
                BirthDate = birthDay,
                IsYoungDriver = isYoungDriver
            };

            using (this.db)
            {
                this.db.Customers.Add(customer);
                this.db.SaveChanges();
            }
        }

        public CustomerModel CustomerToEdit(int id)
        {
            var customerById = this.db.Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerModel
                {
                    Name = c.Name,
                    Birthday = c.BirthDate
                })
                .FirstOrDefault();

            return customerById;
        }

        public void Edit(int id, string name, DateTime birthday)
        {
            bool isYoungDriver = this.IsYoungDriver(birthday);

            using (this.db)
            {
                var customer = this.db.Customers
                    .FirstOrDefault(c => c.Id == id);

                customer.Name = name;
                customer.BirthDate = birthday;
                customer.IsYoungDriver = isYoungDriver;

                this.db.SaveChanges();
            }
        }

        private bool IsYoungDriver(DateTime birthDay)
        {
            var age = (DateTime.Now - birthDay).Days / 365.25m;
            var experience = age - 18;

            return experience < 2.0m;
        }
    }
}