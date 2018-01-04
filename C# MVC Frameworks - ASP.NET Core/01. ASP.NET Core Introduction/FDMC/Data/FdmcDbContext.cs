namespace FDMC.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class FdmcDbContext : DbContext
    {
        public FdmcDbContext(DbContextOptions<FdmcDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
    }
}