namespace ProductShop
{
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static void Main()
        {
            ShopDbContext context = new ShopDbContext();
            context.Database.Migrate();

            ImportDataJson importData = new ImportDataJson(context);
            //importData.ImportUsersFromJson();
            //importData.ImportCategoriesFromXml();
            //importData.ImportProductsFromJson();

            QueryExportDataJson queryExportDataJson = new QueryExportDataJson(context);
            //queryExportDataJson.QueryProductsInRange();
            //queryExportDataJson.QuerySuccessSoldProducts();
            //queryExportDataJson.QueryCategoriesByProductsCount();
            //queryExportDataJson.QueryUsersAndProducts();

            ImportDataXml importDataXml = new ImportDataXml(context);
            //importDataXml.ImportUsersFromXml();
            //importDataXml.ImportCategoriesFromXml();
            //importDataXml.ImportProductsFromXml();

            QueryExportDataXml queryExportDataXml = new QueryExportDataXml(context);
            //queryExportDataXml.QueryProductsInRange();
            //queryExportDataXml.QuerySuccessSoldProducts();
            //queryExportDataXml.QueryCategoriesByProductsCount();
            //queryExportDataXml.QueryUsersAndProducts();
        }
    }
}