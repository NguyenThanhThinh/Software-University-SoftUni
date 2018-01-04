namespace CarDealer.Web.Controllers
{
    using App.Models.Suppliers;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Services.Contracts;

    public class SuppliersController : Controller
    {
        private readonly ISupplierSurvice supplierService;

        public SuppliersController(ISupplierSurvice supplierService)
        {
            this.supplierService = supplierService;
        }

        public IActionResult Local()
        {
            var localSuppliers = this.GetSupplierModel(false);

            return this.View("Suppliers", localSuppliers);
        }

        public IActionResult Importers()
        {
            var importerSuppliers = this.GetSupplierModel(true);

            return this.View("Suppliers", importerSuppliers);
        }

        private SuppliersModel GetSupplierModel(bool isImporter)
        {
            string type = isImporter ? "Importer" : "Local";

            var supplier = new SuppliersModel
            {
                SuppliersModels = this.supplierService.Locals(true),
                Type = type
            };

            return supplier;
        }
    }
}