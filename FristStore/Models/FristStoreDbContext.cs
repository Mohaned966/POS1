using FristStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FristStore.Models
{
    public class FristStoreDbContext : DbContext
    {
        public FristStoreDbContext(DbContextOptions<FristStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ProductMovement> ProductMovements { get; set; }
        public DbSet<ProductReport> ProductReports { get; set; }
        public DbSet<AccountReport> AccountReports { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }

    }
}
