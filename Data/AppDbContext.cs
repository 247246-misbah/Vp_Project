using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Models;

namespace Misbah_VisualProgramming_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Aapke core database tables ke sets
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<HardwareStatus> HardwareStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // FORCE MAPPING: Yeh lines EF ko majboor karengi ke galat naam dhoondne ke bajaye exact aapki tables se connect kare
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<HardwareStatus>().ToTable("hardwarestatus"); // Agar phpMyAdmin mein naam 'hardware_status' hai toh wo likhein
            modelBuilder.Entity<User>().ToTable("user");
        }
    }
}