using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Models;
using System;
using System.Threading;

namespace Misbah_VisualProgramming_Project.Services
{
    public class HardwareService : IDisposable
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly Timer _timer;
        private readonly Random _random = new Random();

        public event Action<HardwareStatus>? OnTelemetryUpdated;

        // FIXED: Injecting DbContextFactory instead of direct DbContext to prevent runtime crashes
        public HardwareService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
            _timer = new Timer(UpdateHardwareTelemetry, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
        }

        private async void UpdateHardwareTelemetry(object? state)
        {
            try
            {
                using var context = await _contextFactory.CreateDbContextAsync();

                // Telemetry simulation values matching your UI cards
                double currentTemp = 90.0 + (_random.NextDouble() * 5.0); // Loops around 92.50°C
                int waterLevel = _random.Next(95, 101); // Around 100%

                var telemetry = await context.HardwareStatuses.FirstOrDefaultAsync();
                if (telemetry == null)
                {
                    telemetry = new HardwareStatus
                    {
                        MachineName = "Espresso Twin-X1",
                        Status = "Idle",
                        BoilerTemp = currentTemp,
                        WaterLevel = waterLevel
                    };
                    context.HardwareStatuses.Add(telemetry);
                }
                else
                {
                    telemetry.BoilerTemp = currentTemp;
                    telemetry.WaterLevel = waterLevel;
                    telemetry.Status = "Idle";
                    context.HardwareStatuses.Update(telemetry);
                }

                await context.SaveChangesAsync();

                // Trigger real-time visual update to dashboard component tree
                OnTelemetryUpdated?.Invoke(telemetry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Telemetry engine sync warning: {ex.Message}");
            }
        }

        public async Task<HardwareStatus> GetLatestStatusAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.HardwareStatuses.FirstOrDefaultAsync()
                   ?? new HardwareStatus { MachineName = "Espresso Twin-X1", Status = "Idle", BoilerTemp = 92.5, WaterLevel = 100 };
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}