namespace CarDealer.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface ISaleService
    {
        IEnumerable<SaleModel> Index();

        IEnumerable<SaleModel> Index(int id);

        IEnumerable<SaleModel> Discounted();

        IEnumerable<SaleModel> Discounted(double percentage);
    }
}