using Misbah_VisualProgramming_Project.Data.Entities;
using System.Threading.Tasks;

namespace Misbah_VisualProgramming_Project.Services
{
    public interface ISensorService
    {
        Task<HardwareSensor?> GetMachineTelemetryAsync();
    }
}