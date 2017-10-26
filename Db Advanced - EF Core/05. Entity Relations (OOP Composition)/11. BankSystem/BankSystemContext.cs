namespace _11._BankSystem
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class BankSystemContext : DbContext
    {
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }

        public DbSet<SavingAccount> SavingAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=BankSystemDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}