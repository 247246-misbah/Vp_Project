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

            // Directly targeting your exact SQL schema table names
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<HardwareStatus>().ToTable("HardwareStatus");
        }
    }
}