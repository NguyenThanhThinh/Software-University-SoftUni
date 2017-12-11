namespace Services
{
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly MappingDbContext context;

        public DatabaseInitializerService(MappingDbContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}