using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Models;
using System;
using System.Threading.Tasks;

namespace Misbah_VisualProgramming_Project.Services
{
    public class HardwareService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public HardwareService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<HardwareStatus> GetLatestStatus()
        {
            try
            {
                using var context = await _contextFactory.CreateDbContextAsync();
                var status = await context.HardwareStatuses.FirstOrDefaultAsync();

                if (status != null) return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database Pipeline Log: {ex.Message}");
            }

            // Fallback object state safe parameters if database row is empty
            return new HardwareStatus
            {
                Id = 1,
                MachineName = "Espresso Twin-X1",
                CurrentState = "Ready",
                Temperature = 92.4,
                WaterLevel = 85,
                BeanWeight = 420,
                IsConnected = true
            };
        }
    }
}