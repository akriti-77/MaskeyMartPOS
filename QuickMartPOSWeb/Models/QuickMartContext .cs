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


            // Seed initial product data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Rice (1 kg)", Category = "Grocery", Price = 1.20m },
                new Product { Id = 2, Name = "Flour (1 kg)", Category = "Grocery", Price = 0.90m },
                new Product { Id = 3, Name = "Sugar (1 kg)", Category = "Grocery", Price = 1.10m },
                new Product { Id = 4, Name = "Cooking Oil (1L)", Category = "Grocery", Price = 3.50m },
                new Product { Id = 5, Name = "Salt (1 kg)", Category = "Grocery", Price = 0.50m },
                new Product { Id = 6, Name = "Lentils (1 kg)", Category = "Grocery", Price = 1.80m },
                new Product { Id = 7, Name = "Turmeric (100g)", Category = "Grocery", Price = 0.60m },
                new Product { Id = 8, Name = "Tea (100g)", Category = "Grocery", Price = 1.50m },

                new Product { Id = 9, Name = "Biscuits (pack)", Category = "Snacks", Price = 1.00m },
                new Product { Id = 10, Name = "Potato Chips (pack)", Category = "Snacks", Price = 1.20m },
                new Product { Id = 11, Name = "Instant Noodles", Category = "Snacks", Price = 0.50m },
                new Product { Id = 12, Name = "Chocolate Bar", Category = "Snacks", Price = 1.50m },

                new Product { Id = 13, Name = "Soft Drink (500ml)", Category = "Beverages", Price = 1.00m },
                new Product { Id = 14, Name = "Juice (1L)", Category = "Beverages", Price = 2.00m },
                new Product { Id = 15, Name = "Beer", Category = "Beverages", Price = 10.00m },
                new Product { Id = 16, Name = "Vodka", Category = "Beverages", Price = 50.00m },
                new Product { Id = 17, Name = "Wine", Category = "Beverages", Price = 30.00m },

                new Product { Id = 18, Name = "Milk (1L)", Category = "Dairy", Price = 1.20m },
                new Product { Id = 19, Name = "Butter (200g)", Category = "Dairy", Price = 2.50m },
                new Product { Id = 20, Name = "Cheese (200g)", Category = "Dairy", Price = 3.00m },
                new Product { Id = 21, Name = "Yogurt (200g)", Category = "Dairy", Price = 0.80m },
                new Product { Id = 22, Name = "Bread (loaf)", Category = "Dairy", Price = 1.00m },

                new Product { Id = 23, Name = "Soap (bar)", Category = "Household", Price = 0.80m },
                new Product { Id = 24, Name = "Detergent (500g)", Category = "Household", Price = 2.00m },
                new Product { Id = 25, Name = "Toothpaste (100g)", Category = "Household", Price = 1.50m },
                new Product { Id = 26, Name = "Shampoo (200ml)", Category = "Household", Price = 3.00m },
                new Product { Id = 27, Name = "Toilet Paper (roll)", Category = "Household", Price = 0.70m },

                new Product { Id = 28, Name = "Toothbrush", Category = "Personal Care", Price = 1.00m },
                new Product { Id = 29, Name = "Hair Oil (100ml)", Category = "Personal Care", Price = 2.00m },
                new Product { Id = 30, Name = "Deodorant", Category = "Personal Care", Price = 2.50m },

                new Product { Id = 31, Name = "Notebook", Category = "Stationery", Price = 1.50m },
                new Product { Id = 32, Name = "Pen", Category = "Stationery", Price = 0.50m },
                new Product { Id = 33, Name = "Batteries (AA, pack of 2)", Category = "Stationery", Price = 2.00m },
                new Product { Id = 34, Name = "Lighter", Category = "Stationery", Price = 0.80m }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
