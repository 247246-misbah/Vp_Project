using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misbah_VisualProgramming_Project.Services
{
    public class OrderService : IOrderService
    {
        private readonly CafeDbContext _context;
        public OrderService(CafeDbContext context) => _context = context;

        public async Task<List<Order>> GetActiveOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }
    }
}