namespace SalesDatabase
{
    public class Startup
    {
        public static void Main()
        {
            SalesDbContext context = new SalesDbContext();
            context.Database.Initialize(true);
        }
    }
}