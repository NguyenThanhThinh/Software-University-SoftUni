namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Parts;

    public class PartService : IPartService
    {
        private readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public bool AddPart(string name, double price, string supplier, int quantity = 1)
        {
            var existingSupplier = this.db.Suppliers.FirstOrDefault(s => s.Name == name);

            if (existingSupplier == null)
            {
                return false;
            }

            var part = new Part
            {
                Name = name,
                Price = price,
                Supplier = existingSupplier,
                Quantity = quantity
            };

            this.db.Parts.Add(part);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<Part> All()
            => this.db.Parts.Include(s => s.Supplier);

        public IEnumerable<PartModel> AllPartNamesAndPrices()
            => this.db.Parts
                .Where(p => p.Quantity > 0)
                .Select(p => new PartModel
                {
                    PartName = p.Name,
                    Price = p.Price
                });

        public bool DeletePart(int id)
        {
            var part = this.db.Parts.FirstOrDefault(p => p.Id == id);

            if (part == null)
            {
                return false;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();

            return true;
        }

        public PartEditModel GetById(int id)
            => this.db.Parts
                .Where(p => p.Id == id)
                .Select(p => new PartEditModel
                {
                    Price = p.Price,
                    Quantity = p.Quantity
                })
                .FirstOrDefault();

        public void EditPart(int id, double? price, int quantity)
        {
            var part = this.db.Parts.FirstOrDefault(p => p.Id == id);

            part.Price = price;
            part.Quantity = quantity;

            this.db.SaveChanges();
        }
    }
}