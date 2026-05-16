using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misbah_VisualProgramming_Project.Models
{
    [Table("HardwareStatus")] // Force matching with your SQL schema table name
    public class HardwareStatus
    {
        [Key]
        [Column("MachineId")]
        public int MachineId { get; set; }

        [Column("MachineName")]
        public string MachineName { get; set; } = "Espresso Twin-X1";

        [Column("WaterLevel")]
        public int WaterLevel { get; set; } = 100;

        [Column("BeanWeight")]
        public int BeanWeight { get; set; } = 1000;

        [Column("Temperature")]
        public double Temperature { get; set; } = 25.0;

        [Column("IsConnected")]
        public bool IsConnected { get; set; } = true;

        [Column("CurrentState")]
        public string CurrentState { get; set; } = "Idle";
    }
}