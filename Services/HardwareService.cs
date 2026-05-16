using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Misbah_VisualProgramming_Project.Services
{
    public class HardwareService : IDisposable
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly Timer _timer;
        private readonly Random _random = new Random();

        public event System.Action<HardwareStatus>? OnTelemetryUpdated;

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

                double currentTemp = 90.0 + (_random.NextDouble() * 5.0); // Simulated boiler target ~92°C
                int waterLevel = _random.Next(95, 101);

                var telemetry = await context.HardwareStatuses.FirstOrDefaultAsync();
                if (telemetry == null)
                {
                    telemetry = new HardwareStatus
                    {
                        MachineName = "Espresso Twin-X1",
                        CurrentState = "Idle",
                        Temperature = currentTemp,
                        WaterLevel = waterLevel,
                        BeanWeight = 950,
                        IsConnected = true
                    };
                    context.HardwareStatuses.Add(telemetry);
                }
                else
                {
                    telemetry.Temperature = currentTemp;
                    telemetry.WaterLevel = waterLevel;
                    telemetry.CurrentState = "Idle";
                    context.HardwareStatuses.Update(telemetry);
                }

                await context.SaveChangesAsync();
                OnTelemetryUpdated?.Invoke(telemetry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Telemetry engine sync warning: {ex.Message}");
            }
        }

        public async Task<HardwareStatus> GetLatestStatus()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.HardwareStatuses.FirstOrDefaultAsync()
                   ?? new HardwareStatus { MachineName = "Espresso Twin-X1", CurrentState = "Idle", Temperature = 92.5, WaterLevel = 100 };
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}