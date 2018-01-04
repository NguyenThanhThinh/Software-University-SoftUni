namespace CarDealer.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Customers;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderCustomers(OrderType orderBy);

        CustomerByIdModel CustomerById(int id);

        void Add(string name, DateTime birthDay);

        CustomerModel CustomerToEdit(int id);

        void Edit(int id, string name, DateTime birthday);
    }
}