using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Data.Entities;
using System.Threading.Tasks;

namespace Misbah_VisualProgramming_Project.Services
{
    public class SensorService : ISensorService
    {
        private readonly CafeDbContext _context;
        public SensorService(CafeDbContext context) => _context = context;

        public async Task<HardwareSensor?> GetMachineTelemetryAsync()
        {
            return await _context.HardwareSensors.FirstOrDefaultAsync();
        }
    }
}