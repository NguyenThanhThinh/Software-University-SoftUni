namespace CarDealer.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface ISupplierSurvice
    {
        IEnumerable<SupplierModel> Locals(bool isImportar);
    }
}