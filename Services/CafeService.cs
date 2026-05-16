using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misbah_VisualProgramming_Project.Services
{
    public class CafeService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public CafeService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Exact method name matching the frontend page requirements
        public async Task<List<Product>> GetProductsAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Products.ToListAsync();
        }
    }
}