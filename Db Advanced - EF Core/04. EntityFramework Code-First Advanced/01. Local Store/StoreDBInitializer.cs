namespace _01.Local_Store
{
    using Models;
    using System.Data.Entity;

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            Product firstProduct = new Product()
            {
                Name = "Beans",
                DistributorName = "v.Turnovo",
                Description = "Something boring which I can't think of now.",
                Price = 2.9M,
                Weight = 0.500M,
                Quantity = 17
            };

            Product secondProduct = new Product()
            {
                Name = "Meat",
                DistributorName = "s.Govedarci",
                Description = "Caw meat. From the mountain.",
                Price = 22.9M,
                Weight = 1M,
                Quantity = 5
            };

            Product thirdProduct = new Product()
            {
                Name = "Eggs",
                DistributorName = "s. Staro Selo",
                Description = "Eggs from happy chickens.",
                Price = 3.9M,
                Weight = 0.200M,
                Quantity = 7
            };

            Product fourthProduct = new Product()
            {
                Name = "Rise",
                DistributorName = "Dobrich",
                Description = "White and good Rise.",
                Price = 4M,
                Weight = 0.500M,
                Quantity = 10
            };

            context.Products.AddRange(new[] { firstProduct, secondProduct, thirdProduct, fourthProduct });

            base.Seed(context);
        }
    }
}