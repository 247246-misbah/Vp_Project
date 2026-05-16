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

        // Fetch Menu Items (CRUD Read)
        public async Task<List<Product>> GetMenuAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Products.Where(p => p.IsAvailable).ToListAsync();
        }

        // Place Order transaction matching Composition Rules
        public async Task<bool> PlaceOrderAsync(Order order)
        {
            using var context = _contextFactory.CreateDbContext();
            try
            {
                context.Orders.Add(order);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}