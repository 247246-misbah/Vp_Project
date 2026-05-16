using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Models;
using System;
using System.Linq;
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
                var status = await context.HardwareStatuses
                    .OrderBy(h => h.MachineId)
                    .FirstOrDefaultAsync();

                if (status != null) return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB Fallback] State Alert: {ex.Message}");
            }

            return new HardwareStatus
            {
                MachineId = 1,
                MachineName = "Espresso Twin-Pro X",
                CurrentState = "Ready to Brew",
                Temperature = 92.0,
                WaterLevel = 85,
                BeanWeight = 400,
                IsConnected = true
            };
        }
    }
}