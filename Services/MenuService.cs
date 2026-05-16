using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misbah_VisualProgramming_Project.Services
{
    public class MenuService : IMenuService
    {
        private readonly CafeDbContext _context;

        // Injecting EF Core DB Context safely to access hardware tables
        public MenuService(CafeDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItem>> GetAllMenuItemsAsync()
        {
            // Ab real SQLite context repository table node read ho rhi hai!
            return await _context.MenuItems.ToListAsync();
        }
    }
}