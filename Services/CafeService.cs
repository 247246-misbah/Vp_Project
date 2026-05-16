using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Models;

namespace Misbah_VisualProgramming_Project.Services
{
    public class CafeService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public CafeService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Products.ToListAsync();
        }
    }
}