namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using Data;
    using Data.Models;
    using Newtonsoft.Json;

    public class ImportDataJson
    {
        private readonly ShopDbContext context;

        public ImportDataJson(ShopDbContext context)
        {
            this.context = context;
        }

        public void ImportUsersFromJson()
        {
            var users = File.ReadAllText("../Resources/users.json");

            var jsonUsers = JsonConvert.DeserializeObject<User[]>(users);

            this.context.Users.AddRange(jsonUsers);

            this.context.SaveChanges();
        }

        public void ImportProductsFromJson()
        {
            var products = File.ReadAllText("../Resources/products.json");

            var jsonProducts = JsonConvert.DeserializeObject<Product[]>(products);

            int[] userIds = this.context.Users.Select(u => u.UserId).ToArray();

            Random random = new Random();

            foreach (var product in jsonProducts)
            {
                int randomId = random.Next(0, userIds.Length);
                int currentUserId = userIds[randomId];

                product.SellerId = currentUserId;

                if (currentUserId % 2 == 0)
                {
                    while (randomId == currentUserId)
                    {
                        randomId = random.Next(0, userIds.Length);
                    }

                    product.BuyerId = userIds[randomId];
                }

                CategoryProduct category = this.ReturnRandomCategory(product.ProductId);
                product.Categories.Add(category);
                this.context.Products.Add(product);
            }

            this.context.SaveChanges();
        }

        private CategoryProduct ReturnRandomCategory(int productId)
        {
            int[] categories = this.context.Categories.Select(c => c.CategoryId).ToArray();

            Random random = new Random();

            int categoryId = random.Next(0, categories.Length);

            CategoryProduct cp = new CategoryProduct
            {
                CategoryId = categories[categoryId],
                ProductId = productId
            };

            return cp;
        }

        public void ImportCategoriesFromJson()
        {
            var categories = File.ReadAllText("../Resources/categories.json");

            var jsonCategories = JsonConvert.DeserializeObject<Category[]>(categories);

            this.context.Categories.AddRange(jsonCategories);

            this.context.SaveChanges();
        }
    }
}