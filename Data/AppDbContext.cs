using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Models; // THIS LINE WAS MISSING AND CAUSING THE ERROR

namespace Misbah_VisualProgramming_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Maps cleanly to your MySQL tables
        public DbSet<Product> Products { get; set; }
        public DbSet<HardwareStatus> HardwareStatuses { get; set; }
    }
}