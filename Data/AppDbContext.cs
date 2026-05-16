using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Models;

namespace Misbah_VisualProgramming_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Mapping C# Models to MySQL Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<HardwareStatus> HardwareStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Standardizing table names to match common plural configurations
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<OrderItem>().ToTable("orderitems");
            modelBuilder.Entity<HardwareStatus>().ToTable("hardwarestatuses");
        }
    }
}
