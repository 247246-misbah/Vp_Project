using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Models;

namespace Misbah_VisualProgramming_Project.Services
{
    public class CafeService
    {
        private readonly AppDbContext _context;

        public CafeService(AppDbContext context)
        {
            _context = context;
        }

        // Fetch all products from MySQL database
        public async Task<List<Product>> GetMenuAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}