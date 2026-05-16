using System.ComponentModel.DataAnnotations;

namespace Misbah_VisualProgramming_Project.Models
{
    public class HardwareStatus
    {
        [Key]
        public int MachineId { get; set; }

        [Required]
        public string MachineName { get; set; } = string.Empty;

        [Required]
        public string CurrentState { get; set; } = string.Empty;

        [Required]
        public double Temperature { get; set; }

        [Required]
        public int WaterLevel { get; set; }

        [Required]
        public int BeanWeight { get; set; }

        [Required]
        public bool IsConnected { get; set; }
    }
}