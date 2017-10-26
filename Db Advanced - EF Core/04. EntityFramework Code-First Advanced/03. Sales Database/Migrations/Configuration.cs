namespace SalesDatabase.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SalesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "SalesDatabase.SalesDbContext";
        }

        protected override void Seed(SalesDbContext context)
        {
        }
    }
}