using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PO> PurchaseOrders { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<GRN> GRN { get; set; }
        public DbSet<Salesperson> Salesperson { get; set; }
        public DbSet<ItemMaster> ItemMaster { get; set; }
        public DbSet<ItemData> ItemData { get; set; }
        public DbSet<BOM> BOM { get; set; }
        public DbSet<Spec> Spec { get; set; }
    }
}