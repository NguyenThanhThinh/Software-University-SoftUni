namespace ProductShop
{
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;
    using Data;

    public class QueryExportDataXml
    {
        private readonly ShopDbContext context;

        public QueryExportDataXml(ShopDbContext context)
        {
            this.context = context;
        }

        public void QueryProductsInRange()
        {
            var products = this.context.Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.BuyerId != null)
                .Select(p => new
                {
                    ProductName = p.Name,
                    Price = p.Price,
                    Buyer = string.Concat(p.Buyer.FirstName, " ", p.Buyer.LastName).Trim()
                })
                .OrderBy(p => p.Price)
                .ToList();

            XDocument xmlDoc = new XDocument();
            xmlDoc.Add(new XElement("products"));

            foreach (var product in products)
            {
                xmlDoc.Root.Add(new XElement("product",
                     new XAttribute("name", product.ProductName),
                     new XAttribute("price", product.Price.ToString(CultureInfo.InvariantCulture)),
                     new XAttribute("buyer", product.Buyer)
                     ));
            }

            xmlDoc.Save("products-in-range.xml");
        }

        public void QuerySuccessSoldProducts()
        {
            var users = this.context.Users
                .Where(u => u.SoldProducts.Count > 0)
                .Select(u => new
                {
                    SellerFirstName = u.FirstName ?? "unknown",
                    SellerLastName = u.LastName,
                    SoldProducts = u.SoldProducts
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                        .ToList()
                })
                .OrderBy(u => u.SellerLastName)
                .ThenBy(u => u.SellerFirstName)
                .ToList();

            XDocument xmlDoc = new XDocument();
            xmlDoc.Add(new XElement("users"));

            foreach (var user in users)
            {
                XElement[] products = new XElement[user.SoldProducts.Count];
                int index = 0;

                foreach (var product in user.SoldProducts)
                {
                    products[index] = new XElement("product",
                                new XElement("name", product.Name),
                                new XElement("price", product.Price));

                    index++;
                }

                xmlDoc.Root.Add(new XElement("user",
                    new XAttribute("first-name", user.SellerFirstName),
                    new XAttribute("last-name", user.SellerLastName),
                    new XElement("sold-products", products)));
            }

            xmlDoc.Save("users-sold-products.xml");
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
                .OrderBy(c => c.ProductsCount)
                .ToList();

            XDocument xmlDox = new XDocument();
            xmlDox.Add(new XElement("categories"));

            foreach (var category in categories)
            {
                xmlDox.Root.Add(new XElement("category",
                                         new XAttribute("name", category.CategoryName),
                                            new XElement("products-count", category.ProductsCount),
                                            new XElement("average-price", category.AvaragePrice),
                                            new XElement("total-revenue"), category.TotalRevenue));
            }

            xmlDox.Save("categories-by-products.xml");
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
                        .ToList()
                })
                .ToList();

            XDocument xmlDoc = new XDocument();
            xmlDoc.Add(new XElement("users",
                new XAttribute("count", users.Count)));

            foreach (var user in users)
            {
                var products = new XElement[user.Products.Count];
                int index = 0;

                foreach (var product in user.Products)
                {
                    products[index] = new XElement("product",
                        new XAttribute("name", product.Name),
                        new XAttribute("price", product.Price));

                    index++;
                }

                // the expression with "user.Property == null ? null : new X("name", value)" is used in a such way,
                // because the LINQ in XML will ignore null values and this way we prevent run-time Errors
                xmlDoc.Root.Add(new XElement("user",
                        user.FirstName == null ? null : new XAttribute("first-name", user.FirstName),
                        new XAttribute("last-name", user.LastName),
                        user.Age == null ? null : new XAttribute("age", user.Age),
                            new XElement("sold-products",
                                new XAttribute("count", user.Products.Count),
                                products)));
            }

            xmlDoc.Save("users-and-products.xml");
        }
    }
}