namespace SalesDatabase
{
    using System;
    using Models;
    using System.Data.Entity;

    public class SalesDbInitializer : DropCreateDatabaseAlways<SalesDbContext>
    {
        protected override void Seed(SalesDbContext context)
        {
            Product firstProduct = new Product()
            {
                Name = "Shampoo",
                Price = 5.2M,
                Quantity = 3
            };

            StoreLocation firstStoreLocation = new StoreLocation()
            {
                LocationName = "bul. Dragan Cankov 54, Sofia"
            };

            Customer firstCustomer = new Customer()
            {
                Name = "Stefcho",
                Email = "stefcho@abv.bg",
                CreditCardNumber = "901192837842283742",
            };

            Sale firstSale = new Sale()
            {
                Product = firstProduct,
                Customer = firstCustomer,
                StoreLocation = firstStoreLocation,
                Date = new DateTime(2017, 10, 14)
            };

            Product secondProduct = new Product()
            {
                Name = "Parfume",
                Price = 150.99M,
                Quantity = 17
            };

            StoreLocation secondStoreLocation = new StoreLocation()
            {
                LocationName = "NYC, 123 Central Park"
            };

            Customer secondCustomer = new Customer()
            {
                Name = "David",
                Email = "david@abv.bg",
                CreditCardNumber = "901192883740293742",
            };

            Sale secondSale = new Sale()
            {
                Product = secondProduct,
                Customer = secondCustomer,
                StoreLocation = secondStoreLocation,
                Date = new DateTime(2017, 09, 13)
            };

            Product thirdProduct = new Product()
            {
                Name = "Cleaning kid",
                Price = 15.99M,
                Quantity = 7
            };

            StoreLocation thirdStoreLocation = new StoreLocation()
            {
                LocationName = "NYC, 93 Central Park"
            };

            Customer thirdCustomer = new Customer()
            {
                Name = "Steve",
                Email = "david@abv.bg",
                CreditCardNumber = "901192888443293731",
            };

            Sale thirdSale = new Sale()
            {
                Product = thirdProduct,
                Customer = thirdCustomer,
                StoreLocation = thirdStoreLocation,
                Date = new DateTime(2016, 09, 13)
            };

            Product fourthProduct = new Product()
            {
                Name = "Tires",
                Price = 559.99M,
                Quantity = 4
            };

            StoreLocation fourthStoreLocation = new StoreLocation()
            {
                LocationName = "ul. Angel Kynchev, Sofia"
            };

            Customer fourthCustomer = new Customer()
            {
                Name = "Pesho",
                Email = "pesho89@abv.bg",
                CreditCardNumber = "901192888938475109",
            };

            Sale fourthSale = new Sale()
            {
                Product = fourthProduct,
                Customer = fourthCustomer,
                StoreLocation = fourthStoreLocation,
                Date = new DateTime(2016, 09, 13)
            };

            Product fifthProduct = new Product()
            {
                Name = "House",
                Price = 333333999.99M,
                Quantity = 1
            };

            StoreLocation fifthStoreLocation = new StoreLocation()
            {
                LocationName = "bul. Andrei Lqpchev 82, Sofia"
            };

            Customer fifthCustomer = new Customer()
            {
                Name = "Ivan",
                Email = "Ivan77@abv.bg",
                CreditCardNumber = "901192888938273645",
            };

            Sale fifthSale = new Sale()
            {
                Product = fifthProduct,
                Customer = fifthCustomer,
                StoreLocation = fifthStoreLocation
            };

            context.Sales.AddRange(new[] { firstSale, secondSale, thirdSale, fourthSale, fifthSale });

            base.Seed(context);
        }
    }
}