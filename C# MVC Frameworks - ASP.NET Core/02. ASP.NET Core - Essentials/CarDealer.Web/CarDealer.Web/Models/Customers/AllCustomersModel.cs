namespace CarDealer.App.Models.Customers
{
    using System.Collections.Generic;
    using Services.Models;
    using Services.Models.Customers;

    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public OrderType OrderType { get; set; }
    }
}