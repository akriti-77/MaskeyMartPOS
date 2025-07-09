using Microsoft.EntityFrameworkCore;

namespace QuickMartPOSWeb.Models
{
    public class QuickMartContext : DbContext
    {
        public QuickMartContext(DbContextOptions<QuickMartContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionItem> TransactionItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);  // Set precision and scale for Price decimal

            base.OnModelCreating(modelBuilder);
        }
    }
}
