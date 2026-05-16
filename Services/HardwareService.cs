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

        public event Action<HardwareStatus>? OnTelemetryUpdated;

        public HardwareService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
            // Background generator simulating virtual espresso twin sensors every 3 seconds
            _timer = new Timer(UpdateHardwareTelemetry, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
        }

        private async void UpdateHardwareTelemetry(object? state)
        {
            try
            {
                using var context = await _contextFactory.CreateDbContextAsync();

                // Advanced Logic: Fluctuating virtual hardware status sensors dynamically
                double targetedTemp = 92.5 + (_random.NextDouble() * 4.0 - 2.0); // Fluctuates safely around 90-94°C
                int localizedWater = _random.Next(80, 101); // Mimicking active water capacity level
                int currentBeans = _random.Next(600, 950);

                string[] availableStates = { "Idle", "Heating Boiler...", "Extracting Espresso Shot", "Steaming Milk Content" };
                string chosenState = availableStates[_random.Next(availableStates.Length)];

                var telemetry = await context.HardwareStatuses.FirstOrDefaultAsync();
                if (telemetry == null)
                {
                    telemetry = new HardwareStatus
                    {
                        MachineName = "Espresso Twin-X1",
                        CurrentState = chosenState,
                        Temperature = targetedTemp,
                        WaterLevel = localizedWater,
                        BeanWeight = currentBeans,
                        IsConnected = true
                    };
                    context.HardwareStatuses.Add(telemetry);
                }
                else
                {
                    // Sync updates smoothly directly back to local MySQL instances
                    telemetry.Temperature = targetedTemp;
                    telemetry.WaterLevel = localizedWater;
                    telemetry.BeanWeight = currentBeans;
                    telemetry.CurrentState = chosenState;
                    context.HardwareStatuses.Update(telemetry);
                }

                await context.SaveChangesAsync();

                // Real-time notification trigger bound straight into the Blazor UI thread pipeline
                OnTelemetryUpdated?.Invoke(telemetry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Digital Twin Engine Exception Captured: {ex.Message}");
            }
        }

        public async Task<HardwareStatus> GetLatestStatus()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.HardwareStatuses.FirstOrDefaultAsync()
                   ?? new HardwareStatus { MachineName = "Espresso Twin-X1", CurrentState = "System Warmup", Temperature = 25.0, WaterLevel = 100 };
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}