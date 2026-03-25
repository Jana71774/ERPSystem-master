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

        // Tables
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Primary Key for tblSpec
            modelBuilder.Entity<Spec>()
                .HasKey(s => new { s.ItemCode, s.SpecId });

            // Optional: map table names (only if you used tbl names in MySQL)
            modelBuilder.Entity<Login>().ToTable("tblLogin");
            modelBuilder.Entity<Customer>().ToTable("tblCustomer");
            modelBuilder.Entity<Product>().ToTable("tblProduct");
            modelBuilder.Entity<PO>().ToTable("tblPO");
            modelBuilder.Entity<Inventory>().ToTable("tblInventory");
            modelBuilder.Entity<GRN>().ToTable("transGRN");
            modelBuilder.Entity<Salesperson>().ToTable("tblSalesperson");
            modelBuilder.Entity<ItemMaster>().ToTable("tblItemMaster");
            modelBuilder.Entity<ItemData>().ToTable("tblItemData");
            modelBuilder.Entity<BOM>().ToTable("tblBOM");
            modelBuilder.Entity<Spec>().ToTable("tblSpec");
        }
    }
}