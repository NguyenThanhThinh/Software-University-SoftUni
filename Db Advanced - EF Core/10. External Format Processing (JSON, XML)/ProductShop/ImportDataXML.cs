namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using Data.Models;

    public class ImportDataXml
    {
        private ShopDbContext context;

        public ImportDataXml(ShopDbContext context)
        {
            this.context = context;
        }

        public void ImportUsersFromXml()
        {
            var users = File.ReadAllText("../Resources/users.xml");

            XDocument xDocument = XDocument.Parse(users);

            var userElements = xDocument.Root.Elements();

            foreach (var user in userElements)
            {
                string firstName = user.Attribute("firstName")?.Value;
                var lastName = user.Attribute("lastName")?.Value;
                int ageNotNull;
                int.TryParse(user.Attribute("age")?.Value, out ageNotNull);
                int? age;

                User currentUser = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = ageNotNull == 0 ? null : (age = ageNotNull)
                };

                this.context.Users.Add(currentUser);
            }

            this.context.SaveChanges();
        }

        public void ImportProductsFromXml()
        {
            var products = File.ReadAllText("../Resources/products.xml");

            XDocument xDocument = XDocument.Parse(products);

            var xmlProducts = xDocument.Root.Elements();

            int[] userIds = this.context.Users.Select(u => u.UserId).ToArray();

            Random random = new Random();

            foreach (var product in xmlProducts)
            {
                int randomId = random.Next(0, userIds.Length);
                int currentUserId = userIds[randomId];

                var currentProduct = new Product
                {
                    Name = product.Element("name")?.Value,
                    Price = decimal.Parse(product.Element("price").Value)
                };

                currentProduct.SellerId = currentUserId;

                if (currentUserId % 2 == 0)
                {
                    while (randomId == currentUserId)
                    {
                        randomId = random.Next(0, userIds.Length);
                    }

                    currentProduct.BuyerId = userIds[randomId];
                }

                CategoryProduct category = this.ReturnRandomCategory(currentProduct.ProductId);
                currentProduct.Categories.Add(category);
                this.context.Products.Add(currentProduct);
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

        public void ImportCategoriesFromXml()
        {
            var categories = File.ReadAllText("../Resources/categories.xml");

            XDocument xDocument = XDocument.Parse(categories);

            var jsonCategories = xDocument.Root.Elements();

            foreach (var category in jsonCategories)
            {
                string name = category.Element("name")?.Value;

                var currentCategory = new Category
                {
                    Name = name
                };

                this.context.Categories.Add(currentCategory);
            }

            this.context.SaveChanges();
        }
    }
}