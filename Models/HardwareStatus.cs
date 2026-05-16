using System.ComponentModel.DataAnnotations;

namespace Misbah_VisualProgramming_Project.Models
{
    public class HardwareStatus
    {
        [Key]
        public int Id { get; set; }

        public string MachineName { get; set; } = "Espresso Twin-X1";

        // Exact names needed by the Telemetry service and Dashboard UI
        public string Status { get; set; } = "Idle";

        public double BoilerTemp { get; set; } = 92.50;

        public int WaterLevel { get; set; } = 100;
    }
}