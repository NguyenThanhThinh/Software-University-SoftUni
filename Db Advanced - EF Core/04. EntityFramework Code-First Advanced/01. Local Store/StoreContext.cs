namespace _01.Local_Store
{
    using Models;
    using System.Data.Entity;

    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("name=StoreContext")
        {
            Database.SetInitializer(new StoreDbInitializer());
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}