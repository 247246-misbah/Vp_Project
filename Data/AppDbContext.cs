using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Models;

namespace Misbah_VisualProgramming_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        // This targets your model mapping
        public DbSet<HardwareStatus> HardwareStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CRUCIAL FIX: Directly telling Entity Framework to look for the exact names from your SQL schema
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<User>().ToTable("Users");

            // FORCING THE EXACT TABLE NAME WITHOUT EXTRA 'es' OR 's'
            modelBuilder.Entity<HardwareStatus>().ToTable("HardwareStatus");
        }
    }
}