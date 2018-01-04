namespace CarDealer.App.Models.Suppliers
{
    using System.Collections.Generic;
    using Services.Models;

    public class SuppliersModel
    {
        public IEnumerable<SupplierModel> SuppliersModels { get; set; }

        public string Type { get; set; }
    }
}