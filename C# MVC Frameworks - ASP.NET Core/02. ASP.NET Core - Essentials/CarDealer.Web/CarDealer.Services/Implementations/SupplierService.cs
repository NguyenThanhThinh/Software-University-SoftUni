namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;

    public class SupplierService : ISupplierSurvice
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> Locals(bool isImporter)
        {
            var localSuppliers = this.db.Suppliers
                .Where(s => s.IsImporter == isImporter)
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    NumberOfParts = s.Parts.Count
                });

            return localSuppliers;
        }
    }
}