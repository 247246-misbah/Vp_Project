using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Models;

namespace Misbah_VisualProgramming_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<HardwareStatus> HardwareStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // FORCE MAPPING: Maps models directly to the exact table names in your phpMyAdmin
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<HardwareStatus>().ToTable("hardwarestatus");
            modelBuilder.Entity<User>().ToTable("user");
        }
    }
}