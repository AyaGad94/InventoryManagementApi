using Microsoft.EntityFrameworkCore;
using InventoryManagementApi.Models;

namespace InventoryManagementApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }
    }
}
