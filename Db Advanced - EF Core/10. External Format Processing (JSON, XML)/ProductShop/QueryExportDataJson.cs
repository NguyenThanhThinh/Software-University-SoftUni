namespace ProductShop
{
    using System.IO;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;

    public class QueryExportDataJson
    {
        private readonly ShopDbContext context;

        public QueryExportDataJson(ShopDbContext context)
        {
            this.context = context;
        }

        public void QueryProductsInRange()
        {
            var products = this.context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    ProductName = p.Name,
                    Price = p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.Price)
                .ToList();

            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented,
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            File.WriteAllText("PricesInRange.json", jsonProducts);
        }

        public void QuerySuccessSoldProducts()
        {
            var products = this.context.Users
                .Where(u => u.SoldProducts.Count > 0)
                .Select(u => new
                {
                    SellerFirstName = u.FirstName,
                    SellerLastName = u.LastName,
                    SoldProducts = u.SoldProducts
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                })
                .OrderBy(u => u.SellerLastName)
                .ThenBy(u => u.SellerFirstName)
                .ToList();

            string jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

            File.WriteAllText("users-sold-products.json", jsonProducts);
        }

        public void QueryCategoriesByProductsCount()
        {
            var categories = this.context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    ProductsCount = c.Products.Count,
                    AvaragePrice = c.Products.Average(p => p.Product.Price),
                    TotalRevenue = c.Products.Sum(p => p.Product.Price)
                })
                .OrderBy(c => c.CategoryName);

            string jsonCategories = JsonConvert.SerializeObject(categories, Formatting.Indented,
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            File.WriteAllText("categories-by-products.json", jsonCategories);
        }

        public void QueryUsersAndProducts()
        {
            var users = this.context.Users
                .Where(u => u.SoldProducts.Count > 0)
                .OrderByDescending(u => u.SoldProducts.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    Products = u.SoldProducts
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                });

            var jsonUsers = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

            File.WriteAllText("users-and-products.json", jsonUsers);
        }
    }
}