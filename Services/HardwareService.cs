using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Models;

namespace Misbah_VisualProgramming_Project.Services
{
    public class HardwareService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        // Dependency Injection with Context Factory for concurrent Blazor threads
        public HardwareService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<HardwareStatus> GetMachineStateAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            var machine = await context.HardwareStatuses.FirstOrDefaultAsync();

            if (machine == null)
            {
                machine = new HardwareStatus
                {
                    MachineName = "Espresso Twin-X1",
                    WaterLevel = 100,
                    BeanWeight = 1000,
                    Temperature = 92.5m,
                    CurrentState = "Idle",
                    IsConnected = true
                };
                context.HardwareStatuses.Add(machine);
                await context.SaveChangesAsync();
            }
            return machine;
        }

        public async Task UpdateHardwareStateAsync(int waterUsed, int beansUsed, decimal tempChange, string newState)
        {
            using var context = _contextFactory.CreateDbContext();
            var machine = await context.HardwareStatuses.FirstOrDefaultAsync();
            if (machine != null)
            {
                machine.WaterLevel = Math.Max(0, machine.WaterLevel - waterUsed);
                machine.BeanWeight = Math.Max(0, machine.BeanWeight - beansUsed);
                machine.Temperature = tempChange;
                machine.CurrentState = newState;

                await context.SaveChangesAsync();
            }
        }
    }
}