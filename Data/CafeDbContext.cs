using Microsoft.EntityFrameworkCore;

namespace Misbah_VisualProgramming_Project.Data
{
    public class CafeDbContext : DbContext
    {
        public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}